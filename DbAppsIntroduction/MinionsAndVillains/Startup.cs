using System;
using System.Data.SqlClient;

namespace MinionsAndVillains
{
    public class Startup
    {
        public static void Main()
        {
            // CreateAndInsertIntoDatabaseMinions();

            // PrintVillainsAndTheirMinionsInDescOrder();

            // GetVillainInfoById();

            // InsertingMinions();
        }

        private static void InsertingMinions()
        {
            var minionInfo = Console.ReadLine().Split();
            var villainInfo = Console.ReadLine().Split();

            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTownName = minionInfo[3];
            var villainName = villainInfo[1];

            var connection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=True");

            connection.Open();
            using (connection)
            {
                var command = new SqlCommand(
                    "INSERT INTO Minions(Name,Age,Id)" +
                    " VALUES (@minionName, @minionAge, (SELECT Id FROM Towns WHERE Name=@minionTownName))", connection);
                command.Parameters.AddWithValue("@minionName", minionName);
                command.Parameters.AddWithValue("@minionAge", minionAge);
                command.Parameters.AddWithValue("@minionTownName", minionTownName);

                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
        }

        private static void GetVillainInfoById()
        {
            var villainId = int.Parse(Console.ReadLine());

            var connection = new SqlConnection(
                "Server=.;Database = MinionsDB;Integrated Security=True");

            connection.Open();
            using (connection)
            {
                var villainCommand = new SqlCommand(
                    "SELECT Name FROM Villains WHERE Id=@villainId", connection);
                villainCommand.Parameters.AddWithValue("@villainId", villainId);

                var villainReader = villainCommand.ExecuteReader();
                while (villainReader.Read())
                {
                    Console.WriteLine($"Villain: {(string)villainReader[0]}");
                }
                villainReader.Close();

                var minionCommand = new SqlCommand(
                    "SELECT m.Name, m.Age FROM Minions AS m "
                    + "JOIN MinionsVillains AS mv ON mv.MinionId = m.Id "
                    + "WHERE mv.VillainId = @villainId ORDER BY m.Name", connection);

                minionCommand.Parameters.AddWithValue("@villainId", villainId);

                var minionReader = minionCommand.ExecuteReader();
                var counter = 1;

                while (minionReader.Read())
                {
                    var name = (string)minionReader["Name"];
                    var age = (int)minionReader["Age"];

                    Console.WriteLine($"{counter}. {name} {age}");

                    counter++;
                }

                minionReader.Close();
            }
        }

        private static void PrintVillainsAndTheirMinionsInDescOrder()
        {
            var connection = new SqlConnection(
                            "Server=.;Database=MinionsDB;Integrated Security=True");

            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT v.Name, COUNT(*) AS NumberMinions FROM Villains AS v "
                            + "JOIN MinionsVillains AS mv ON mv.VillainId = v.Id "
                            + "GROUP BY v.Name "
                            + "ORDER BY COUNT(*) DESC", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var villain = (string)reader["Name"];
                    var numberMinions = (int)reader["NumberMinions"];

                    Console.WriteLine($"{villain} - {numberMinions}");
                }

                reader.Close();
            }
        }

        private static void CreateAndInsertIntoDatabaseMinions()
        {
            var connection = new SqlConnection(
                            "Server=.;Integrated Security=True");

            connection.Open();
            using (connection)
            {
                try
                {
                    var createDbQuery = "CREATE DATABASE MinionsDB";
                    ExecuteCommand(createDbQuery, connection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connection = new SqlConnection(
                "Server=.;Database=MinionsDB;Integrated Security=True");

            connection.Open();

            using (connection)
            {
                try
                {
                    string createCountriesSQL = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                    string createTownsSQL = "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryId INT NOT NULL, CONSTRAINT FK_TownCountry FOREIGN KEY (CountryId) REFERENCES Countries(Id))";
                    string createMinionsSQL = "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), Age INT, TownId INT, CONSTRAINT FK_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id))";
                    string createEvilnessFactorsSQL = "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY, Name VARCHAR(10) UNIQUE NOT NULL)";
                    string createVillainsSQL = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT, CONSTRAINT FK_VillainEvilnessFactor FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id))";
                    string createMinionsVillainsSQL = "CREATE TABLE MinionsVillains(MinionId INT, VillainId INT, CONSTRAINT FK_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id), CONSTRAINT  FK_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))";

                    ExecuteCommand(createCountriesSQL, connection);
                    ExecuteCommand(createTownsSQL, connection);
                    ExecuteCommand(createMinionsSQL, connection);
                    ExecuteCommand(createEvilnessFactorsSQL, connection);
                    ExecuteCommand(createVillainsSQL, connection);
                    ExecuteCommand(createMinionsVillainsSQL, connection);

                    string insertCountriesSQL = "INSERT INTO Countries VALUES ('Bulgaria'), ('United Kingdom'), ('United States of America'), ('France')";
                    string insertTownsSQL = "INSERT INTO Towns (Name, CountryId) VALUES ('Sofia',1), ('Burgas',1), ('Varna', 1), ('London', 2),('Liverpool', 2),('Ocean City', 3),('Paris', 4)";
                    string insertMinionsSQL = "INSERT INTO Minions (Name, Age, TownId) VALUES ('bob',10,1),('kevin',12,2),('stuart',9,3), ('rob',22,3), ('michael',5,2),('pep',3,2)";
                    string insertEvilnessFactorsSQL = "INSERT INTO EvilnessFactors VALUES (1, 'Super Good'), (2, 'Good'), (3, 'Bad'), (4, 'Evil'), (5, 'Super Evil')";
                    string insertVillainsSQL = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru', 2),('Victor', 4),('Simon Cat', 3),('Pusheen', 1),('Mammal', 5)";
                    string insertMinionsVillainsSQL = "INSERT INTO MinionsVillains VALUES (1, 2), (3, 1), (1, 3), (3, 3), (4, 1), (2, 2), (1, 1), (3, 4), (1, 4), (1, 5), (5, 1)";

                    ExecuteCommand(insertCountriesSQL, connection);
                    ExecuteCommand(insertTownsSQL, connection);
                    ExecuteCommand(insertMinionsSQL, connection);
                    ExecuteCommand(insertEvilnessFactorsSQL, connection);
                    ExecuteCommand(insertVillainsSQL, connection);
                    ExecuteCommand(insertMinionsVillainsSQL, connection);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ExecuteCommand(string command, SqlConnection connection)
        {
            var sql = new SqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
    }
}
