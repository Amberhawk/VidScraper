using System;
using System.Net;
using System.Text;
using System.IO;
using System.Web;
namespace YoutubeRipperV0
{
    class YoutubeRipperV0
{

// Resources for magic numbers:
//   MAGIC NUMBER	FORMAT	RESOLUTION	CODECS
// 171	webm	audio only	vorbis
// 140	m4a	audio only	mp4a
// 133	mp4	426x240	avc1 video only
// 134	mp4	640x360	avc1 video only
// 135	mp4	854x480	avc1 video only
// 247	webm	1280x720	vp9 video only
// 136	mp4	1280x720	avc1 video only
// 248	webm	1920x1080	vp9 video only
// 137	mp4	1920x1080	avc1 video only
// 43	webm	640x360	vp8 + vorbis
// 18	mp4	640x360	avc1 + mp4a
// 22	mp4	1280x720	avc1 + mp4a
      private static int LoopCounterOne= 0;
      private static String OGUrl= "";
      private static string FileName = "";
      private static String UrlData = "";
      private static String[] UrlDataTEMP;
      private static String SearchGoal_GoogleVideo = "googlevideo";
      private static String SearchGoal_VideoPlayback = "videoplayback";
      private static String SearchGoal_itag = "itag=";

      private static String SearchGoal_itag_MP4_144p = "itag=160";
      private static String SearchGoal_itag_MP4_360p = "itag=18";
      private static String SearchGoal_itag_MP4_720p = "itag=137";
      private static String SearchGoal_itag_MP4_1080p = "itag=37";


      private static String SearchGoal_itag_WEBM_360p = "itag=43";
      private static String SearchGoal_itag_WEBM_480p = "itag=44";
      private static String SearchGoal_itag_WEBM_720p = "itag=45";
      private static String SearchGoal_itag_WEBM_1080p = "itag=46";


      private static String SearchGoal_itag_M4A_48k = "itag=139";
      private static String SearchGoal_itag_M4A_128k = "itag=140";
      private static String SearchGoal_itag_M4A_256k = "itag=141";

      private static String autoFileNameStart = "\\";
      private static String FileNameExtension = ".txt";
      private static String FileNameExtension_MP4 = ".mp4";
      private static String FileNameExtension_M4A = ".m4a";
      private static String FileNameExtension_WEBM= ".webm";



      static void Main(string[] args)
        {
          Console.WriteLine("Enter Youtube URL: ");
          OGUrl = Console.ReadLine();
          Console.WriteLine("Enter File Name: ");
          FileName = Console.ReadLine();
          if(FileName.Equals("")){
            FileName = "Default";
          }


          var webclient = new WebClient();
          UrlData = webclient.DownloadString(OGUrl);

        //  Console.WriteLine("HERE1");
          UrlData = UrlData.Replace("http","QWERGHYIJ123123#$@SFCVSVSBhttp");
          UrlData = UrlData.Replace("\"","QWERGHYIJ123123#$@SFCVSVSB\"");
          UrlData = UrlData.Replace("\\u0026", "&");
          UrlDataTEMP = UrlData.Split("QWERGHYIJ123123#$@SFCVSVSB");
          UrlDataTEMP = UrlData.Split("QWERGHYIJ123123#$@SFCVSVSB");


          String[] UrlDataTEMP2 = new String[UrlDataTEMP.Length];

          FindVideoURL(SearchGoal_itag_MP4_720p,UrlDataTEMP2);
          FileNameExtension = FileNameExtension_MP4;
          Console.WriteLine(UrlDataTEMP2[0]);
          if(UrlDataTEMP2[0] ==null){
            Console.WriteLine("No File found. Shutting down.");
            System.Environment.Exit(1);
          }


          String currentDir = Directory.GetCurrentDirectory();
          using (StreamWriter sw = File.CreateText(currentDir+autoFileNameStart+FileName+FileNameExtension))  { }

          webclient.DownloadFile(UrlDataTEMP2[0],currentDir+autoFileNameStart+FileName+FileNameExtension);
        }

        private static void FindVideoURL(string version, string[] tempArray){
          string decode = "";
          foreach(var url in UrlDataTEMP){
            if(url.Contains(SearchGoal_GoogleVideo)){
              if(url.Contains(SearchGoal_VideoPlayback)){
                decode = url;
                decode = HttpUtility.UrlDecode(decode);
                decode = HttpUtility.UrlDecode(decode);
                decode = HttpUtility.UrlDecode(decode);
                decode = HttpUtility.UrlDecode(decode);
                decode = HttpUtility.UrlDecode(decode);
                //Console.WriteLine(decode);
                if(decode.Contains(version)){
                  tempArray[LoopCounterOne] = decode;
                  LoopCounterOne +=1;
                }
              }
            }
          }
        }



}
}
