# Console Task Manager
## Method 1. Creating the task

```
> add
> Enter a title
> {title}
> Enter a description
> {summary}
> Enter the deadline
> {dueDate}
> Enter the type
> {type}
> Assign the priority
> {priority}

```


#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | Task title |
|summary | string, not required | Description of what needs to be done|
|dueDate | datetime (nullable), not required | By what date the task is planned to be completed|
|type | enum [Work, Study, Personal], required | Task type |
|priority| enum [Low, Normal, High], not required (default value: Normal)| Task priority |


## Method 2. Task List

```
> list
```

## Method 3. Completing the task

```
> done
> Enter a title
> {title}
```


#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |


## Method 4. The task is not relevant

```
> wontdo
> Enter a title
> {title}
```


#### Input parameters

|Argument|Type|Description|
|---|---|---|
| title |string, required | The title of the required task to close |


## Exit

```
> quit
```

or

```
> q
```
