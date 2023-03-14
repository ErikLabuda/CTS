using HtmlAgilityPack;

//stiahni a parsuj stranku 
var html1 = "https://www.cts-tradeit.cz/kariera/";
HtmlWeb webHome = new HtmlWeb();
HtmlDocument htmlJobs = await webHome.LoadFromWebAsync(html1);



var avJobs = htmlJobs.DocumentNode.SelectNodes("//*[@id=\"snippet--content\"]/div/section/div/div/div/div/a/div/h3");







foreach (var avJob in avJobs)
{

    //zisti nazov pozicie 
   var jobName = avJob.InnerText.Trim();
    Console.WriteLine(jobName);

    //zisti url konkretnej pozicie (funguje len pri prvej pozicii - .NET Developer, neviem prist na chybu
   var jobUrl = "https://www.cts-tradeit.cz" + avJob.SelectSingleNode("//*[@id=\"snippet--content\"]/div/section/div/div/div/div/a").GetAttributeValue("href", "");
    //stiahne a parsuje html web
    HtmlDocument jobHome = await webHome.LoadFromWebAsync(jobUrl);

    //vypise url pozicii, je to tu len pre tesotvanie ci funguje spravne 
    Console.WriteLine(jobUrl);

    //zober text z casti "Co vas na teto pozici ceka
    string jobDes = jobHome.DocumentNode.SelectSingleNode("//*[@id=\"snippet--content\"]/div/section[5]/div/div/div/div[2]/div[1]").InnerText.Trim();

    Console.WriteLine(jobDes);


    //zapis do textoveho suboru

    string name = jobName + ".txt";
    File.WriteAllText(name, jobDes);



}





