#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define S 1
#define D 3
#define N 10
#define T 10
#define FPS 30

int main()
{
	char outputFileName[100];
	double startTime, endTime;
	int startFrame[N], endFrame[N];
	//int humanID;
	
	//printf("당신의 ID를 입력하세요.\n");
	//scanf("%d",&humanID); 
	
	for(int s=1; s<=S; s++)
	for(int d=1; d<=D; d++)
	{
		sprintf(outputFileName,"C:\\Users\\User\\Desktop\\피실험자%d\\HUMAN_DATA\\output%02d_human.txt",s,d);
		FILE *output=fopen(outputFileName,"wb");
		for(int n=0;n<N;n++)
		{
			printf("피실험자%d | test%02d : %d번째 거북목 구간을 입력하세요.\n",s,d,n);
			//scanf("%lf %lf\n",&startTime,&endTime);
			//startFrame=(int)(startTime*FPS)-FPS*T*(n-1);
			//endFrame=(int)(endTime*FPS)-FPS*T*(n-1);
			scanf("%d%d",&startFrame[n],&endFrame[n]);
			
		}
		int n=0;
		bool isRecording=false;
		for(int f=0; f<FPS*T*N; f++)
		{
			if(f==startFrame[n])
				isRecording=true;
			if(f==endFrame[n])
				isRecording=false, n++;
			if(isRecording)
				fprintf(output,"1\r\n");
			else fprintf(output,"0\r\n");
		}
	}
}
