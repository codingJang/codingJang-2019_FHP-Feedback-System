#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define S 1
#define D 5
#define N 10
#define T 10
#define FPS 30
#define NUM_min 2
#define NUM_delta 2
#define NUM_max 6
#define THETA_C_min 3.0
#define THETA_C_delta 1.0
#define THETA_C_max 15.1

typedef struct
{
	int frame;
	double vect[4][3];
	double angle;
}data;

int main()
{
	char inputFileName[100];
	char outputFileName[100];
	
	for(int s=1; s<=S; s++)
	for(int d=1; d<=D; d++)
	for(int num=NUM_min; num<=NUM_max; num+=NUM_delta)
	for(double theta_c=THETA_C_min; theta_c<=THETA_C_max; theta_c+=THETA_C_delta)
	{
	
	sprintf(inputFileName,"C:\\Users\\User\\Desktop\\피실험자%d\\RAW_DATA\\test%02d.txt",s,d);
	sprintf(outputFileName,"C:\\Users\\User\\Desktop\\피실험자%d\\OUTPUT_DATA\\output%02d_cavg%02d_%.1f.txt",s,d,num,theta_c);
	FILE *input=fopen(inputFileName,"rb");
	FILE *output=fopen(outputFileName,"wb");
	
	data tempData;
	data Array[10][300];
	
	double tempTheta[NUM_max];
	double theta, sumTheta, avgTheta;
	bool isForward;
	
	for(int n=0;n<N;n++)
	{
		for(int f=0;f<FPS*T;f++)
		{
			fscanf(input, "%d", &tempData.frame);
			tempData.frame/=2;
			
			for(int i=0;i<4;i++)
				for(int j=0;j<3;j++)
					fscanf(input, "%lf", &tempData.vect[i][j]);
			
			fscanf(input, "%lf", &tempData.angle);
			Array[n][f]=tempData;
		}
	}
	
	for(int n=0;n<N;n++)
	{
		for(int f=0;f<FPS*T;f++)
		{
			theta=Array[n][f].angle;
			isForward=Array[n][f].vect[3][0]>=0?true:false;
			
			if(f<num)
			{
				tempTheta[f]=theta;
				sumTheta+=theta;
				avgTheta=theta;
			}
			else
			{
				sumTheta-=tempTheta[(f+num/2)%num];
				tempTheta[f%num]=theta;
				sumTheta+=theta;
				avgTheta=sumTheta/num;
			}
			if(isForward&&avgTheta>theta_c)
				fprintf(output,"1\r\n");
			else fprintf(output,"0\r\n");
		}
	}
	}
	return 0;
}
