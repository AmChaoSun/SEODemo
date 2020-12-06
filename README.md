# Instructions
This is the backend part for SEO Demo.\

Advertisements have been excluded.\

Currently, only three kinds of search engines are supported:\
1.InfoTrack Static Google pages\
2.Google\
3.Bing\

# Features:\
1.Strategy Pattern is the main pattern for services.\
2.Repository Pattern has been adapt to Database layer.(In-memory database used)\
3.Unit test project with Xunit and Moq\
4.Swagger page endpoint as default starting endpoint(NSwagger)\
5.Logging via Serilog(write to local file)\

#API Example for post Search method\
/api/SEO\
{\
  "engine": "Bing",\
  "input": "online title search",\
  "target": "https://www.infotrack.com.au"\
}\
Note: for "engine" parameter, only "Bing", "InfoTrackGoogle", "Google" are valid for now.\
POST method can be checked with the frontend project while GET method can only be verified via Swagger\

# Future Improvements:\
1.More unit tests\
2.More logs\
3.GetAll() Method can be moved to places other than in EngineService, not quite fit my original design for EngineService\
4.Authentication & Authorizatoin via JWT
etc.

Thanks for your time, feel free to contact me about what needs to be improved or added.
