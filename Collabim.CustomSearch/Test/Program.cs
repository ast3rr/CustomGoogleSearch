// See https://aka.ms/new-console-template for more information
using Collabim.CustomSearch.Business;

Console.WriteLine("Hello, World!");

var searchService = new SearchService();

var searchResult = await searchService.Search("ahoj");