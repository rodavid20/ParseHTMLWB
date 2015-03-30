Try the follwoing:

Remove all other References to Interop.SHDocVw.dll
Right Click your solution and select 'Clean Solution'
Reference the Interop.SHDocVw.dll that is provided by WatiN
Build your solution.
Additionally, change the option for Embed Interop Types to false, and set the Copy Local option to true.