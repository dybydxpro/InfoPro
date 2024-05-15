using Microsoft.AspNetCore.Mvc;
using Planning.Models;

namespace Planning.Services.Context;

public interface IFileGenService
{
    Task<FileContentResult> HandleSpredsheets(PreProcess preProcess);
}