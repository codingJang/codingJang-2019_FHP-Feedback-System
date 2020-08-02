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
	
	//printf("����� ID�� �Է��ϼ���.\n");
	//scanf("%d",&humanID); 
	
	for(int s=1; s<=S; s++)
	for(int d=1; d<=D; d++)
	{
		sprintf(outputFileName,"C:\\Users\\User\\Desktop\\�ǽ�����%d\\HUMAN_DATA\\output%02d_human.txt",s,d);
		FILE *output=fopen(outputFileName,"wb");
		for(int n=0;n<N;n++)
		{
			printf("�ǽ�����%d | test%02d : %d��° �źϸ� ������ �Է��ϼ���.\n",s,d,n);
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
