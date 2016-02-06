.POSIX:
.PHONY: all

all: UseMef.exe SomePlugin.dll

USEMEF_SOURCES = UseMef.cs
UseMef.exe: $(USEMEF_SOURCES)
	mcs /o:'$(@)' $(USEMEF_SOURCES) /r:System.ComponentModel.Composition

SOMEPLUGIN_SOURCES = SomePlugin.cs
SomePlugin.dll: UseMef.exe $(SOMEPLUGIN_SOURCES)
	mcs /o:'$(@)' /t:library $(SOMEPLUGIN_SOURCES) /r:UseMef.exe
