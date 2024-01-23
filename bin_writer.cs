using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 예제로 사용할 크기 지정
        int arraySize = 10;

        // 랜덤한 32비트 float 배열 생성
        float[] randomFloatArray = GenerateRandomFloatArray(arraySize);

        // 파일에 쓰기
        string filePath = "randomFloatArray.bin";
        WriteFloatArrayToFile(filePath, randomFloatArray);

        Console.WriteLine($"랜덤 Float 배열이 {filePath} 파일에 성공적으로 쓰여졌습니다.");
    }

    static float[] GenerateRandomFloatArray(int size)
    {
        Random random = new Random();
        float[] floatArray = new float[size];

        for (int i = 0; i < size; i++)
        {
            // 랜덤한 32비트 float 값 생성
            floatArray[i] = (float)random.NextDouble();
        }

        return floatArray;
    }

    static void WriteFloatArrayToFile(string filePath, float[] floatArray)
    {
        // 파일에 쓰기 모드로 BinaryWriter 열기
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            // 배열의 각 요소를 파일에 쓰기
            foreach (float value in floatArray)
            {
                writer.Write(value);
            }
        }
    }
}
