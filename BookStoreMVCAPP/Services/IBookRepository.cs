﻿using BookStoreMVCAPP.Models;

namespace BookStoreMVCAPP.Services
{
    public interface IBookRepository :IBaseRepository<Book>
    {
        IEnumerable<LanguageCount> BookCountByLanguage();
    }
}
