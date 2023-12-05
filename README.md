## File Manager Console Application

> Development using .NET 6 SDK, support C# 9 Language Version

This console application was created for the purpose of learning the C# language. It enable user with some(and maybe more) functionalities:

- View a table of all files in a directory (including file size and last access timestamp).
- View a table of all subfolders in a directory (pretty much the same idea as above).
- Create, delete, move, rename, read text from and write text to files, as well as searching text files for specific phrases.
- Create, delete, move and rename folders.
- Create and save an 'index.txt' file, which displays all of the files and subfolders in a directory, with some useful information (basically the same thing as the first 2 bullet points, but in a HANDY and CONVENIENT text file).
- Colorful console animation!

name: Release

on:
  push:
    tags:
      - "v*"

jobs:
  build:
    runs-on: windows-latest

    steps:
    - uses: actions/checkout@v2

    - name: Setup MSBuild.exe
      uses: microsoft/setup-msbuild@v1.0.0

    - name: Build with MSBuild
      run: msbuild WslShortcut.sln -p:Configuration=Release

    - name: Upload
      uses: marvinpinto/action-automatic-releases@latest
      with:
        repo_token: "${{ secrets.GITHUB_TOKEN }}"
        prerelease: false
        files: |
          ./bin/WslShortcut.exe
