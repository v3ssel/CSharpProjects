# JSON/YAML one-depth configuration Loader

## JSON

### Input parameters

```
$ dotnet run “{filePath}”
```

|Argument|Type|Description|
|---|---|---|
| filePath |string | Path to a json file |

### Example of launching an application from the project folder

```
Configuration
Port: 1234
CheckForUpdates: True
Domain: http://localhost
Source: JSON
```

## YAML

### Input parameters

```
$ dotnet run “{filePath}”
```

|Argument|Type|Description|
|---|---|---|
| filePath |string | Path to a yaml file |

### Example of launching an application from the project folder

```
Configuration
CheckForUpdates: false
Port: 8080
Source: YAML
Application: ex03
```

## Priorities

### Input parameters

```
$ dotnet run “{jsonPath}” {jsonPriority} “{yamlPath}” {yamlPriority}
```

|Argument|Type|Description|
|---|---|---|
| jsonPath |string | Path to a json file |
| jsonPriority |int | Priority of a json file |
| yamlPath |string | Path to a yaml file |
| yamlPriority |int | Priority of a yaml file |

### Example of launching an application from the project folder

```
$ dotnet run “pathToJson” 1 “pathToYaml” 2
Configuration
Source: YAML
Application: ex03
CheckForUpdates: false
Domain: http://localhost
Port: 8080
```

```
$ dotnet run “pathToJson” 1 “pathToYaml” 0
Configuration
CheckForUpdates: True
Application: ex03
Port: 1234
Source: JSON
Domain: http://localhost
```
