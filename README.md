## Application description

This application shows different formates of different values for 3 main locales: EN, FR, and UA.
After running it you can check the next values that depend on language:
- Dates
- Numbers(with currency sign)
- Units of measurement

## How to run the application

In order to run this application, please follow the next steps:
- Download .NET SDK 6.0 https://dotnet.microsoft.com/en-us/download/dotnet
- Download any IDE like Rider or Visual Studio 2022
- Copy this repo to your machine
- Open *UC14Localization.sln* file 
- Run the application from IDE

## Example of changing language from URL
If you wish to change language from one to another using URI, there are some examples:
- *https://localhost:7271/?culture=en* - to get a page with the English language
- *https://localhost:7271/?culture=fr* - to get a page with the French language
- *https://localhost:7271/?culture=uk-UA* - to get a page with the Ukrainian language

Here, https://localhost:7271 is your local host.

Please note: **If you will try another language abbreviature in the URL, you will be directed to the English language by default**

