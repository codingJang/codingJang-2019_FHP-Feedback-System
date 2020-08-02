#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define S 1
#define D 3
#define N 10
#define T 10
#define FPS 30
#define THETA_C_min 3.0
#define THETA_C_delta 1.0
#define THETA_C_max 15.1

int main()
{
	char filterType[100]="null";
	
	char inputFileName1[100];
	char inputFileName2[100];
	char outputFileName[100];
	
	for(int s=1; s<=S; s++)
	for(int d=1; d<=D; d++)
	for(double theta_c=THETA_C_min; theta_c<=THETA_C_max; theta_c+=THETA_C_delta)
	{	
	sprintf(inputFileName1,"C:\\Users\\User\\Desktop\\피실험자%d\\HUMAN_DATA\\output%02d_human.txt",s,d);
	sprintf(inputFileName2,"C:\\Users\\User\\Desktop\\피실험자%d\\OUTPUT_DATA\\output%02d_%s_%.1f.txt",s,d,filterType,theta_c);
	sprintf(outputFileName,"C:\\Users\\User\\Desktop\\피실험자%d\\CMP_DATA\\output%02d_human-output%02d_%s_%.1f.txt",s,d,d,filterType,theta_c);
	
	FILE *in1=fopen(inputFileName1,"rb");
	FILE *in2=fopen(inputFileName2,"rb");
	FILE *out=fopen(outputFileName,"wb");
	
	int temp1,temp2,cnt=0;
	for(int f=0;f<3000;f++)
	{
		fscanf(in1,"%d",&temp1);
		fscanf(in2,"%d",&temp2);
		fprintf(out,"%d %d %d %d\r\n",f,temp1,temp2,temp1==temp2?1:0);
		if(temp1==temp2) cnt++;
	}
	printf("filterType: %s | subject%d | test%02d | theta_c: %.1f | accuracy: %.2f%%\n",filterType,s,d,theta_c,(float)cnt/30);
	fprintf(out,"filterType: %s | subject%d | test%02d | theta_c: %.1f | accuracy: %.2f%%",filterType,s,d,theta_c,(float)cnt/30);
	}
}
