﻿using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;

namespace ExerciseTracker.K_MYR;

public class DapperContext
{
    private readonly string _connectionString;
    public DapperContext()
    {        
        _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        CreateTables();
    }

    private async void CreateTables()
    {
        try
        {
            var sql = @"CREATE TABLE IF NOT EXISTS Exercises 
        ( 
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartTime String ,
            EndTime String,
            Duration INTEGER,
            Comments String 
        )";

        using var connection = CreateConnection();
        await connection.ExecuteAsync(sql);   
        }
        catch (Exception ex)
        {            
            throw new Exception($"Couldn't create database: {ex.Message}");
        }        
    }

    public IDbConnection CreateConnection() => new SqliteConnection(_connectionString);
}