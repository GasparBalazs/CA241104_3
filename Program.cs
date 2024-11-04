using CA241104_3;
using System.Net.WebSockets;
using System.Text;

List<Versenyzo> versenyzok = [];
using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok
    .Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29 versenyzok: {f1} fo");

var f2 = versenyzok
    .Average(v => 2014 - v.Szul);
Console.WriteLine($"ferfiak atlageletkora: {f2:0.00} ev");

var f3 = versenyzok
    .Sum(v => v.VersenyIdok["úszás"].TotalHours);
Console.WriteLine($"uszassal toltott ido: {f3:0.00} ora");

var f4 = versenyzok
    .Where(v => v.Kategoria == "elit")
    .Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"elit k.ban az atlagos uszassal toltott ido: {f4:0.00} perc");

var f5 = versenyzok
    .Where(v => v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"noi gyoztes {f5}");

var f6 = versenyzok
    .GroupBy(v => v.Kategoria);
Console.WriteLine($"a versenyt befejezok kategoria szerint:");
foreach (var grp in f6)
    Console.WriteLine($"\t{(grp.Key),5}: {grp.Count()} fo");

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(
    g => g.Key,
    g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine("kategoriankent atlag depoban toltott ido");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}

//
TimeSpan ts01 = new(2, 01, 30, 00);
TimeSpan ts02 = new(02, 00, 00);

Console.WriteLine(ts01 + ts02);

Console.WriteLine(ts01.TotalHours);
//
