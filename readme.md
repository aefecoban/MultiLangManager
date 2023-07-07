# Multi Lang Manager

This is a repository prepared to add multiple language support to games for Unity. It is currently in the development stage.

The MultiLangManager class works as a Singleton and should be attached to a game object.
Necessary configurations should be made via the Unity Editor.
Language files should have the .json extension and should be located inside the folder specified in the "Location" variable, which is inside the "Streaming Assets" folder.
Data is retrieved using the GetText function. If there is no corresponding text, TextCode is returned.
