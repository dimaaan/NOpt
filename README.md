# NOpt

Small and flexible command line parser

## Usage

* Create POCO to hold options

* Create a boolean property to hold a flag
``` cs
[Option(shortName: 'f', longName: "flag")]
public bool flag { get; set; };
```
or more shorter
``` cs
[Option('f', "flag")]
public bool flag  { get; set; };
```
Now if you call `progam -f` or `program --flag` this flag will be set to `true`.
> You can use only short name or only long name or both to name your flag

* Create property to hold option with value like
``` cs
[Option('p', "path")]
public string path  { get; set; };
```
Now you can call `program --path path\to\file` or `program --path=path\to\file`

* Create property for nameless option.
``` cs
[Value(0)]
public string directory  { get; set; };
```
Now you can call `program mydirectory` or `program --path path\to\file mydirectory`
> Value has only one parameter - index of nameless option. Indexes are zero based.

* Create an array field if you want vararg feature
``` cs
[Value(1)]
public string[] otherParams { get; set; }; 
```
Now you can call `program mydirectory a b c` and `otherParams` will be set to `{"a", "b", "c"}`

* If you want to restrict option values use enumeration
``` cs 
enum Color {RED, GREEN, NO_COLOR}
```
``` cs
[Option('c', "color")]
public Color color  { get; set; };
```
Now you can call `program --color=no-color` or `program --color=red`

* If you want default value for option: 
``` cs
public Color color { get; set; } = Color.RED;`
```
> Same can be appiled to any other other option or value

* After option class is ready
``` cs
class Program
{
    static void Main(string[] args)
    {
        var opt = NOpt.Parse<Options>(args);
    }
	
	// Use opt!
}
```
