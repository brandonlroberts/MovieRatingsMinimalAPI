﻿namespace MovieRatingsMinimalAPI.Services.Interfaces
{
    public interface IMariaDBService
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);
    }
}