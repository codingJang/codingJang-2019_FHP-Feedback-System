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
	printf("측정 횟수?: ");
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
		printf("%d초 동안 기다리세요\n",startTime);
		delay(startTime);
		puts("목을 앞으로 빼세요");
		delay(interval2);
		puts("원상태");
		delay(interval1-interval2-startTime);
		puts("INTERVAL FINISHED"); 
		puts("");
	}
	
}
