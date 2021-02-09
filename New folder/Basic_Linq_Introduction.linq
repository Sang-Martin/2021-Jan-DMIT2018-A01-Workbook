<Query Kind="Expression">
  <Connection>
    <ID>9b6cf92b-5cae-49de-a2fd-8ef20c95b651</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//method syntax (code as objects)
Albums
.Select(currentrow => currentrow)

//query syntax
from placeholder in Albums
select placeholder

/--------------------------
//partial table rows
//in this example we will create a new output instance layout
//the default layout is the specified receiving field names and order
//the data that fills the new output instance comes from the current row of the table

//query syntax
from x in Albums
select new
{
	Title = x.Title,
	Year = x.ReleaseYear
}

//method syntax
Albums
.Select (x=> new
			{
				Title = x.Title,
				Year = x.ReleaseYear
			}
		)
//---------End--------

//---------Start----------
//WHERE clause
//is used for filtering your selections

//query syntax
from x in Albums
where x.ReleaseYear == 1990
select x.Title  

//method syntax
Albums
.Where(x => (x.ReleaseYear == 1990))
.Select(x => x)
//----------End----------


//------------Start--------------
//ORDERBY clause
//accending or descending

//query syntax
from x in Albums
where x.ReleaseYear >= 1990 && x.ReleaseYear < 2000
orderby x.ReleaseYear ascending, x.Title descending
select x

//method syntax
Albums
	.Where (x => ((x.ReleaseYear >= 1990) && (x.ReleaseYear < 2000)))
	.OrderBy (x => x.ReleaseYear)
	.ThenByDescending(x => x.Title)

//------------End--------------

   
   
   
//Exercise
//Create a list of albums showing the Album title, artist name and release year for 
//	the good old 70's. Order alphabetically by artist then title

//query syntax
from x in Albums
where x.ReleaseYear < 1980 && x.ReleaseYear >= 1970
orderby x.Artist.Name, x.Title
select new 
{
	Title = x.Title,
	ArtistName = x.Artist.Name,
	ReleaseYear = x.ReleaseYear
}

//method syntax
Albums
.Where (x => (x.ReleaseYear < 1980 && x.ReleaseYear >= 1970))
.OrderBy (x => x.Artist.Name)
.ThenBy (x => x.Title)
.Select(x => new {Artist = x.Artist.Name, Title = x.Title, ReleaseYear = x.ReleaseYear})











