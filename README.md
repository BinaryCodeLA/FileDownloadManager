# FileDownloadManager
Download File Organizer for Windows

## What is FileDownloadManager?
It is a program for Windows that allows us to organize our files in the Downloads folder automatically, depending on file type.
As shown below.

![1](https://user-images.githubusercontent.com/47802830/89145583-7ce71980-d50e-11ea-88b9-e1e9463bea18.PNG)

## How to install it?
### Requeriments
   * Visual Studio 2019
   * .NET Framework 4.6.1 or higher
   * Microsoft visual studio 2019 installer projects
   * Right click on FileDownLoadManagerSetup and select Build
   
![2](https://user-images.githubusercontent.com/47802830/89145861-3645ef00-d50f-11ea-99c9-a59b1a3c7fb7.PNG)

    * Right click on FileDownLoadManagerSetup and select Open Folder in FileExplorer
    * Enter the release directory and doble clic on FileDownLoadManagerSetup.msi
    
![3](https://user-images.githubusercontent.com/47802830/89146289-7f4a7300-d510-11ea-8311-fccd79f94086.PNG)
    
    
    *Continue the wizard
    
![4](https://user-images.githubusercontent.com/47802830/89146458-07307d00-d511-11ea-97db-975d8cece064.PNG)

   *When finished, the default path of the "Download" folder will be changed. Enter the program's installation directory and edit the file "DownloadManager.exe.config"

![5](https://user-images.githubusercontent.com/47802830/89146726-c4bb7000-d511-11ea-9631-ddbb18f234a4.PNG)

  *Change Value: "C:\Users\DrCode\Downloads\" for your download directory and save.

![6](https://user-images.githubusercontent.com/47802830/89146872-47dcc600-d512-11ea-8802-6da6f8cc677e.PNG)

  *Restart the FileDownloadManager service in services.msc to read the new changes.
  
![7](https://user-images.githubusercontent.com/47802830/89147014-c174b400-d512-11ea-858c-57a3eff4df16.PNG)
