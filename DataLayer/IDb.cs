﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDb<T, K> where K : IConvertible
    {
        Task CreateAsync(T item);

        Task<T> ReadAsync(K key, bool useNavigationalProperties = false, bool isReadOnly = true);

        Task<List<T>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true);

        Task UpdateAsync(T item, bool useNavigationalProperties = false, bool isReadOnly = true);

        Task DeleteAsync(K key);
    }
}
