# JSON Loader of books and movies top from New York Times

## Search

### Input parameters

```
> Input search text:
```

|Argument|Type|Description|
|---|---|---|
| search |string | Search string |

### Example of launching an application from the project folder

```
$ dotnet run
> Input search text:
ar

Items found: 6

Book search result [3]:
- THE MIDNIGHT LIBRARY by Matt Haig [6 on NYT's Hardcover Fiction]
Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.
https://www.amazon.com/dp/0525559477?tag=NYTBSREV-20
- THE INVISIBLE LIFE OF ADDIE LARUE by V.E. Schwab [9 on NYT's Hardcover Fiction]
A Faustian bargain comes with a curse that affects the adventure Addie LaRue has across centuries.
https://www.amazon.com/dp/0765387565?tag=NYTBSREV-20
- KLARA AND THE SUN by Kazuo Ishiguro [13 on NYT's Hardcover Fiction]
An "Artificial Friend" named Klara is purchased to serve as a companion to an ailing 14-year-old girl.
https://www.amazon.com/dp/059331817X?tag=NYTBSREV-20

Movie search result [3]:
- IN OUR MOTHERS' GARDENS
The Netflix documentary sets out to show how maternal lineages have shaped generations of Black women.
https://www.nytimes.com/2021/05/06/movies/in-our-mothers-gardens-review.html
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
- THINGS HEARD & SEEN
Amanda Seyfried and James Norton move into a haunted house in this busy, creaky Netflix thriller.
https://www.nytimes.com/2021/04/29/movies/things-heard-and-seen-review.html

```

## The Best

### Example of launching an application from the project folder

```
$ dotnet run best
Best in books:
- SOOLEY by John Grisham [1 on NYT's Hardcover Fiction]
Samuel Sooleymon receives a basketball scholarship to North Carolina Central and determines to bring his family over from a civil war-ravaged South Sudan.
https://www.amazon.com/dp/0385547684?tag=NYTBSREV-20

Best in movie reviews:
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
```
