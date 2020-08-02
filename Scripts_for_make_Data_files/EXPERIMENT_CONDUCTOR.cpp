#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void delay(int sec)
{
	int milsec = 1000 * sec;
	clock_t s = clock();
	while(clock()<s+milsec)
	;
}

int chooseStartTime(int interval1, int interval2)
{
	srand(time(NULL));
	return rand()%(interval1-interval2);
}



int main()
{
	int N, interval1, interval2;
	printf("���� Ƚ��?: ");
	scanf("%d",&N);
	printf("INTERVAL1 = ");
	scanf("%d",&interval1);
	printf("INTERVAL2 = ");
	scanf("%d",&interval2); 
	//scanf("%d %d %d",&N, &interval1, &interval2);
	for(int i=0;i<N;i++)
	{
		int startTime=chooseStartTime(interval1, interval2);
		puts("");
		puts("INTERVAL STARTED");
		printf("%d�� ���� ��ٸ�����\n",startTime);
		delay(startTime);
		puts("���� ������ ������");
		delay(interval2);
		puts("������");
		delay(interval1-interval2-startTime);
		puts("INTERVAL FINISHED"); 
		puts("");
	}
	
}
