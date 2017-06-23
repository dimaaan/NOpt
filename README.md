# NOpt

Small, flexible and crossplatform command line parser.

> Target: .NET Standard 1.4


## Show me the code

``` cs
class Options {
    [Option('f', "flag")]
    public bool Flag  { get; set; }

    [Option('p', "path")]
    public string Path  { get; set; }

    [Value(0)]
    public string[] OtherOpts { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var opt = NOpt.NOpt.Parse<Options>(args)
        // Use opt!
    }
}
```

## Usage

1) install with `Install-Package NOpt`

2) define a class that holds an options

3) call NOpt.Parse method to get an options


### Flags

Create a boolean property to hold a flag
``` cs
[Option(shortName: 'f', longName: "flag")]
public bool Flag { get; set; }
```
or more shorter
``` cs
[Option('f', "flag")]
public bool Flag  { get; set; }
```
Now if you call `progam -f` or `program --flag` this flag will be set to `true`.
> You can use only short name or only long name or both to name your flag


### Options with value

Create property to hold option with value like
``` cs
[Option('p', "path")]
public string Path  { get; set; }
```
Now you can call 

`program -p path\to\file` or 

`program --path path\to\file` or 

`program --path=path\to\file`

Option propery can be an array also:
``` cs
[Option('p', "pets")]
public string[] Pets  { get; set; }
```

So

`program -p cats dogs` or

`program --pets cats dogs`

will set `Pets` field to `{"cats", "gods"}`
> You can't use `program --pets=cats dogs` syntax here

### Nameless option.

``` cs
[Value(0)]
public string Dir  { get; set; }
```
Now you can call 

`program mydir` or 

`program --path path\to\file mydir`
> Value attribute has only one parameter - index of nameless option. Indexes are zero based.


### Arrays, vararg feature

``` cs
[Value(1)]
public string[] OtherParams { get; set; }
```
Now you can call `program mydir a b c` and `otherParams` will be set to `{"a", "b", "c"}`
> mydir option was ignored because we don't have property with attribute `[Value(0)]` here


### Enumerations
``` cs 
enum Color {RED, GREEN, NO_COLOR}
```
``` cs
[Option('c', "color")]
public Color color  { get; set; }
```
Now you can call 

`program -c no-color` or 

`program --color no-color` or 

`program --color=no-color` or 

`program --color=no_color` or 

`program --color=NO_COLOR` or 

`program --color=red`

What to pass multiply values? Just add [Flags] attribute to your enumeration:

``` cs 
[Flags] enum Color {RED, GREEN, NO_COLOR}
```

and use `program -c red,green` to set flags
> No spaces allowed between "red,green"

### Default value
NOpt don't touch property default value when there is no corresponding options. 

So just use:
``` cs
public Color color { get; set; } = Color.RED;
```

fills naturally, right?


### Verbs

Check this git-like options:
``` cs
public class Options
{
    [Option("help")]
    public bool help { get; set; }

    [Verb("add")]
    public Add add { get; set; }

    [Verb("commit")]
    public Commit commit { get; set; }

    [Verb("push")]
    public Push push { get; set; }
}

class Add
{
    [Value(0)]
    public string[] files { get; set; }
}

class Commit
{
    [Option("amend")]
    public bool amend { get; set; }

    [Option('m', "message")]
    public string message { get; set; }

    [Value(0)]
    public string[] files { get; set; }
}

class Push
{
    [Option("repo")]
    public string repo { get; set; }

    [Option('f', "force")]
    public bool force { get; set; }

    [Option('v', "verbose")]
    public bool verbose { get; set; }
}
```

With this options you can:

`program add file1 file2`

`program commit -m 'initial commit'`

`program push -repo origin`

>Verbs are mutually exclusive so `program add push` will fail.

Remember that NOpt don't touch properties default values so to check what verb was used:
``` cs
if(opt.help != null) {
    // show help
}
else if(opt.add != null) {
    // use opt.add
}
else if(opt.commit != null) {
    // use opt.commit
}
...
else {
    // no verbs? show a hint
}
```
