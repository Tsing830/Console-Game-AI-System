using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEngine.UI;
using Excel;
using System.Data;

public class ReadExcel : MonoBehaviour
{
    public GameObject Text;
    public int MaxColumn;
    public static ReadExcel Instance;
    static readonly string filePath ="/test.xlsx";
    static readonly string messageDataPath ="/message.xlsx";
    string information;
    public int[] RandomInts = new int[5];


    public string[] type1;
    public string[] type2;
    public string[] type3;
    public string[] type4;
    public string[] type5;
    public string[] type6;
    public string[] type7;
    public string[] type8;
    public string[] type9;
    public string[] type10;
    public string[] type11;
    public string[] type12;
    public string[] type13;
    public string[] messageD;
    public string[] messageD1;
    public string[] messageD2;
    
    
    void Awake()
    {


        

        if(Instance == null) 
            Instance = this;
        else
            Destroy(this);



        


        type1 = getData(1);
        type2 = getData(2);
        type3 = getData(3);
        type4 = getData(4);
        type5 = getData(5);
        type6 = getData(6);
        type7 = getData(7);
        type8 = getData(8);
        type9 = getData(9);
        type10 = getData(10);
        type11 = getData(11);
        type12 = getData(12);
        type13 = getData(13);

        messageD = GetMessageData(0,9);
        messageD1 = GetMessageData(1,4);
        messageD2 = GetMessageData(1,4);


        

    }

    public BaseVideo getVideoData( int type = 0 ) //从excel中获取视频信息
    {
        BaseVideo basevideo = new BaseVideo();
        //FileInfo fileinfo = new FileInfo(filePath);
        //通过excel表格文件信息打开excel表格
        int RandomInt = getRandomInt(MaxColumn);
        if(type == 0)
            {
                type = Random.Range(1, 13);
            }


        if(type == 1)
        {
            basevideo.Name = type1[RandomInt];
            basevideo.Type = type1[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(60, 181);
            basevideo.videoQuality = 100;
        }
        else if(type == 2)
        {
            basevideo.Name = type2[RandomInt];
            basevideo.Type = type2[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(30, 91);
            basevideo.videoQuality = 100;
        }
        else if(type == 3)
        {
            basevideo.Name = type3[RandomInt];
            basevideo.Type = type3[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(30, 91);
            basevideo.videoQuality = 100;
        }
       else if(type == 4)
        {
            basevideo.Name = type4[RandomInt];
            basevideo.Type = type4[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(30, 91);
            basevideo.videoQuality = 100;
        }
        else if(type == 5)
        {
            basevideo.Name = type5[RandomInt];
            basevideo.Type = type5[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(300, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 6)
        {
            basevideo.Name = type6[RandomInt];
            basevideo.Type = type6[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(300, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 7)
        {
            basevideo.Name = type7[RandomInt];
            basevideo.Type = type7[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(300, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 8)
        {
            basevideo.Name = type8[RandomInt];
            basevideo.Type = type8[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(80, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 9)
        {
            basevideo.Name = type9[RandomInt];
            basevideo.Type = type9[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(80, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 10)
        {
            basevideo.Name = type10[RandomInt];
            basevideo.Type = type10[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(100, 300);
            basevideo.videoQuality = 100;
        }
        else if(type == 11)
        {
            basevideo.Name = type11[RandomInt];
            basevideo.Type = type11[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(100, 600);
            basevideo.videoQuality = 100;
        }
        else if(type == 12)
        {
            basevideo.Name = type12[RandomInt];
            basevideo.Type = type12[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(80, 200);
            basevideo.videoQuality = 100;
        }
        else if(type == 13)
        {
            basevideo.Name = type13[RandomInt];
            basevideo.Type = type13[0];
            basevideo.Typeint = type;
            basevideo.videoTime = Random.Range(300, 600);
            basevideo.videoQuality = 100;
        }



        // using (ExcelPackage excelPackage = new ExcelPackage(fileinfo))
        // {   
            
            
        //     ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[type]; //取第张表
        //     basevideo.Name = worksheet.Cells[RandomInt , 1].Value.ToString();
        //     basevideo.Type = worksheet.Cells[RandomInt , 2].Value.ToString();
        //     basevideo.Typeint = type;
        //     basevideo.videoTime = float.Parse(worksheet.Cells[RandomInt , 3].Value.ToString());
        //     basevideo.videoQuality = float.Parse(worksheet.Cells[RandomInt , 4].Value.ToString());

        // }
        
        //video.transform.GetChild(6).GetComponent<Text>() = VideoQueue[i].videoTime;

        return basevideo;
    }


    public BaseNews getNewsData( int type,int number = 0 ) //从excel中获取消息信息
    {
        
        BaseNews baseNews = new BaseNews();

       

        if (type == 1)
        {
            int RandomInt = getRandomInt(8);
            baseNews.newsContent = messageD[RandomInt];
        }
        else if(type == 2)
        {
            int RandomInt = getRandomInt(8);
            baseNews.newsContent = messageD1[RandomInt];
        }
        else if (type == 3)
        {
            baseNews.newsContent = messageD2[number];

        }
        return baseNews;
    }



    public int getRandomInt ( int max)  //获得一个1到max的随机数并且五次内不会重复
    {
        int Randomint = 0;

        if(max < 5)
            Debug.Log("随机数总量不够");
        else
        {
            

            int number = 0;
            while (number != RandomInts.Length )
            {
                Randomint = Random.Range(2 , max+1);
                
                for (int i = 0; i < RandomInts.Length; i++)
                {
                    if(Randomint != RandomInts[i])
                        number++;
                }

                if(number == RandomInts.Length)
                {
                    break;
                }
                else
                {
                    number = 0;
                }
            }




            for (int i = 0; i < RandomInts.Length; i++)
            {
                if(i == RandomInts.Length-1)
                {
                    RandomInts[i] = Randomint;
                }
                else
                {
                    RandomInts[i] = RandomInts[i+1];
                }
            }
        }
        return Randomint;
    }


    public string typeIntToString(int typeInt)
    {
        string typeString = "";

        FileStream flieStream = File.Open(Application.streamingAssetsPath + filePath, FileMode.Open , FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(flieStream);
        DataSet result = excelReader.AsDataSet();

        DataTable  table;

        table = result.Tables[typeInt-1];
        
        typeString = table.Rows[1][1].ToString();
        

        return typeString;

    }

    public string[] getData( int Type)
    {

        string[] data = new string[30];


        FileStream flieStream = File.Open(Application.streamingAssetsPath+filePath, FileMode.Open , FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(flieStream);
        DataSet result = excelReader.AsDataSet();

        DataTable  table;

        table = result.Tables[Type-1];

        data[0] = table.Rows[1][1].ToString();



        for (int i = 1; i < 30; i++)
        {
            data[i] =  table.Rows[i][0].ToString();
        }
        
        return data;
    }

    public string[] GetMessageData( int type,int number)
    {
        string[] data = new string[30];
        FileStream flieStream = File.Open( Application.streamingAssetsPath + messageDataPath, FileMode.Open , FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(flieStream);
        DataSet result = excelReader.AsDataSet();

        DataTable  table;

        table = result.Tables[type];

        for (int i = 0; i < number; i++)
        {
            data[i] =table.Rows[i][0].ToString();

        }

        return data;
    }

        







}
