using HtmlAgilityPack;

//stiahni a parsuj stranku 
var html1 = "https://www.cts-tradeit.cz/kariera/";
HtmlWeb webHome = new HtmlWeb();
HtmlDocument htmlJobs = await webHome.LoadFromWebAsync(html1);
string path = Directory.GetCurrentDirectory();



//vyber elementu s ktorym budeme pracovat 
var jobURLs = htmlJobs.DocumentNode.SelectNodes("//*[@id=\"snippet--content\"]/div/section/div/div/div/div/a");

foreach (var jobURL in jobURLs)
{
    //pridaj k url hodnotu atributu "a" a vytvor tak novu url
    var jobUrl = "https://www.cts-tradeit.cz" + jobURL.GetAttributeValue("href", "");
    //parsuj html z novej url
    HtmlDocument jobHome = await webHome.LoadFromWebAsync(jobUrl);

    //vyber text ktory sa nachadza v h1
    //vyber text z div elementu, ktory ma nazov triedy 'story__text'

    string jobName = jobHome.DocumentNode.SelectSingleNode("//*[@id=\"snippet--content\"]/div/section/div/div/div/div/h1").InnerText.Trim();
    string jobDes = jobHome.DocumentNode.SelectSingleNode("//div[contains(@class, 'story__text')]").InnerText.Trim();


    //tu som len testoval funkcnost.
    //ak by som chcel len vypisat v cmd vsetky potrebne udaje, program funguje, avsak pri zapisovani to textoveho suboru zapise len prve dve pozicie. 

    Console.WriteLine(jobName);
    Console.WriteLine(jobDes);
    Console.WriteLine(jobUrl);
    Console.WriteLine();
    Console.WriteLine();



    string name = jobName + ".txt";

    Console.WriteLine(name.Replace(@"\", "").Replace("/", ""));

    await File.WriteAllTextAsync(name.Replace(@"\", "").Replace("/", ""), jobDes);
}














