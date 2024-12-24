﻿namespace TaskManagement.Application.Wrappers
{
    public class PagedResponse<T> : APIResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = string.Empty;
            Succeed = true;
            Errors = new System.Collections.Generic.List<string>();
        }
    }
}
