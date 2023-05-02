# Weather Info WebAPI

Get token here - [OpenWeather API](<https://openweathermap.org/current>)

And place it in `appsettings.*.json`

## Swagger documentation available in Development enviroment at
```
https://localhost:7777/swagger/index.html
```

## GET weather by coordinates

```
GET https://localhost:7777/weatherforecast/coordinates?lat=9.3&lon=23.1
```

### Example of a call

```
{
    wind: 
    {
            speed: 4.47
    },
    weather: 
    [
            {
                      description: "overcast clouds"
            }
    ],
    main: 
    {
            temp: 29.27,
            pressure: 1007,
            humidity: 57
    },
    name: "Kizicheskaya"
}
```

## GET weather by city

```
GET https://localhost:7777/weatherforecast/kazan
```

### Example of a call

```
{
    wind: 
    {
            speed: 4.49
    },
    weather: 
    [
            {
                      description: "overcast clouds"
            }
    ],
    main: 
    {
            temp: 29.34,
            pressure: 1007,
            humidity: 57
    },
    name: "Kazan’"
}
```

## POST default city


```
GET https://localhost:7777/weatherforecast/
```
Will return 404, but if you:

```
POST https://localhost:7777/weatherforecast/kazan
```
Then:
```
GET https://localhost:7777/weatherforecast/
```
Will return weather of city Kazan.

