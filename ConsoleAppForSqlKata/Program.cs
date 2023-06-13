using Microsoft.Data.SqlClient;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

public class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=GMSK-STJ-1A4NGK\\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            SqlServerCompiler compiler = new SqlServerCompiler();
            QueryFactory queryFactory = new QueryFactory(connection, compiler);

            while (true)
            {
                Console.WriteLine("Sorgu Seçenekleri:");
                Console.WriteLine("1. Kategoriye Göre Ürün Sayısı");
                Console.WriteLine("2. Çalışanların Toplam Satış Miktarı");
                Console.WriteLine("3. Çalışanların Toplam Satış Miktarı (50'den fazla olanlar)");
                Console.WriteLine("4. Çalışanlar ve İlgili Bölgeleri");
                Console.WriteLine("5. Belirli Bir Çalışanın Bölgesi");
                Console.WriteLine("6. Ürünler ve Kategorileri");
                Console.WriteLine("7. Stok Adedi 20 ile 50 Arasında Olan ve Baş Harfi 'B' Olan Kategorilerdeki Ürünler");
                Console.WriteLine("8. Çıkış");

                Console.WriteLine("Seçiminizi yapın (1-7):");
                string optionChoice = Console.ReadLine();

                if (optionChoice == "8")
                    break;

                if (optionChoice != "1" && optionChoice != "2" && optionChoice != "3" && optionChoice != "4" && optionChoice != "5" && optionChoice != "6" && optionChoice != "7")
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    continue;
                }

                Query query = new Query();

                switch (optionChoice)
                {
                    // Kategoriye Göre Ürün Sayısı
                    case "1":
                        query.Select("c.CategoryName")
                            .SelectRaw("COUNT(p.ProductID) AS ToplamAdet")
                            .From("Products as p")
                            .Join("Categories as c", "c.CategoryID", "p.CategoryID")
                            .GroupBy("c.CategoryName");
                        break;
                    // Çalışanların Toplam Satış Miktarı
                    case "2":
                        query = new Query("Employees as e")
                            .SelectRaw("e.FirstName + ' ' + e.LastName AS CalisanAdSoyad")
                            .SelectRaw("SUM(od.Quantity * od.UnitPrice) AS ToplamSatisMiktari")
                            .Join("Orders as o", "o.EmployeeID", "e.EmployeeID")
                            .Join("Order Details as od", "od.OrderID", "o.OrderID")
                            .GroupByRaw("e.FirstName + ' ' + e.LastName");
                        break;
                    // Çalışanların Toplam Satış Miktarı (50'den fazla olanlar)
                    case "3":
                        query.SelectRaw("CONCAT(e.FirstName, ' ', e.LastName) AS CalisanAdSoyad")
                            .SelectRaw("COUNT(od.Quantity * od.UnitPrice) AS ToplamSatisMiktari")
                            .From("Orders as o")
                            .Join("Employees as e", "e.EmployeeID", "o.EmployeeID")
                            .Join("Order Details as od", "od.OrderID", "o.OrderID")
                            .GroupByRaw("CONCAT(e.FirstName, ' ', e.LastName)")
                            .HavingRaw("COUNT(o.OrderID) > 50");
                        break;
                    // Çalışanlar ve İlgili Bölgeleri
                    case "4":
                        query.SelectRaw("e.LastName + ' ' + e.FirstName AS AdSoyad")
                            .Select("t.TerritoryDescription")
                            .From("Employees as e")
                            .Join("EmployeeTerritories as et", "et.EmployeeID", "e.EmployeeID")
                            .Join("Territories as t", "t.TerritoryID", "et.TerritoryID");
                        break;
                    // Belirli Bir Çalışanın Bölgesi
                    case "5":
                        Console.WriteLine("Çalışan soyadlarını seçin:");
                        Console.WriteLine("1. Davolio");
                        Console.WriteLine("2. Fuller");
                        Console.WriteLine("3. Leverling");

                        Console.Write("Seçiminizi yapın (1, 2, 3, ...): ");
                        int selectedIndex = int.Parse(Console.ReadLine());

                        string selectedLastName = "";
                        switch (selectedIndex)
                        {
                            case 1:
                                selectedLastName = "Davolio";
                                break;
                            case 2:
                                selectedLastName = "Fuller";
                                break;
                            case 3:
                                selectedLastName = "Leverling";
                                break;
                        }
                        query = new Query("Employees as e")
                            .SelectRaw("e.LastName + ' ' + e.FirstName AS AdSoyad")
                            .Select("t.TerritoryDescription")
                            .From("Employees as e")
                            .Join("EmployeeTerritories as et", "et.EmployeeID", "e.EmployeeID")
                            .Join("Territories as t", "t.TerritoryID", "et.TerritoryID")
                            .Where("e.LastName", selectedLastName);
                        break;
                    // Ürünler ve Kategorileri
                    case "6":
                        query.Select("p.ProductName")
                            .SelectRaw("(SELECT CategoryName FROM Categories WHERE CategoryID = p.CategoryID) AS CategoryName")
                            .From("Products as p");
                        break;
                    // Stok adedi 20 ile 50 arasında olan ve baş harfi b olan kategorilerdeki ürünler
                    case "7":
                        query = new Query("Products as p")
                            .WhereBetween("p.UnitsInStock", 20, 50)
                            .Join("Categories as c", join =>
                            {
                                return join.On("c.CategoryID", "p.CategoryID")
                                .WhereLike("c.CategoryName", "B%");
                            })
                            .Select("p.ProductName")
                            .Select("c.CategoryName");
                        break;
                }

                try
                {
                    // mssql sorgusu
                    string sqlQuery = compiler.Compile(query).Sql;
                    Console.WriteLine("MSSQL Sorgusu:");
                    Console.WriteLine(sqlQuery);

                    // sorgu sonucunu
                    IEnumerable<dynamic> result = queryFactory.FromQuery(query).Get<dynamic>();

                    Console.WriteLine("Sorgu Sonuçları:");
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }

                Console.WriteLine();
            }
        }

        Console.ReadLine();
    }
}
