#include <iostream>
#include <iomanip>
using namespace std;
int n, a, b;													//n=高度 a=層數 b=樹幹高度
int main() {
	cin >> n;													//總高度
	if (n > 10) {
		while (n > 0) {											//樹葉有幾層
			n = n - 3 - a;
			a++;
			b = n + a + 3 - 1;									//計算剩餘的部分當作樹幹
		}
		if (b == 0)												//以樹幹代替完先著地的一層樹葉
			b = a + 3 - 1;
		for (int i = 0; i < a - 1; i++) 						//有幾層  將樹幹去掉所以減一
			for (int j = 0; j < 3 + i; j++) {					//一層有幾片 每層多加i
				for (int l = 0; l < 2 * (a - 1) - i - j; l++)		//每層間隔都會多2 以i減去整層定值 以j減去每層數值 
					cout << setw(1) << "";
				for (int k = 0; k < 2 * (i + j) + 1; k++)		//一片幾個 i改變起始一片樹葉有幾個 j改變每片寬度
					cout << "*";								//輸出符號*
				cout << endl;									//每執行完一片換行
			}

		for (int i = 0; i < b; i++) {							//樹幹多高
			for (int m = 0; m < 2 * (a - 1); m++)					//計算樹根距離樹中心多少
				cout << setw(1) << "";
			cout << "*";
			cout << endl;
		}
		system("Pause");										//以便觀賞聖誕樹
	}
}
/*
簡介:先以高度來判斷有幾層樹,再把後來多餘的當作樹幹,假如剛好都是樹葉,自行減去一層,將其變成樹幹
輸入輸出規則:輸入:樹的高度 輸出:聖誕樹圖型
計算公式,原理說明:高度換算成樹的層數:以遞減的方式 每運算一次計算一層(a)並將(b)記為樹幹高度				Line08-Line12
				  當最後剩餘的部分剛好等同樹葉(沒有樹幹時)將最後一層樹葉轉化成樹幹						Line13-Line14
				  第一層迴圈:表示層數要輸出幾次由(a-1(樹幹))決定										Line15
				  第二層迴圈:表示每層要輸出幾片樹葉(橫排),起始3片,每多一層多加1片(變數i)				Line16
				  第三層-1迴圈:輸出其間隔數																Line17
								 2*a=最高層的固定間隔
								 j=每片的遞減(使葉片擴散)
								 i=每層的起始減去的間隔數
				  第三層-2迴圈:輸出符號*																Line19
								 2*(i+j)=每一片所需要的符號*
									j=每片+1
									i=每層+1
								 1=中間樹幹
				 第一層迴圈:輸出樹幹高度(b)																Line24
				 第二層迴圈:計算距離樹幹需多少間隔														Line25
							2*(a-1)=每一層的間隔為2,因此將最高層數去掉樹幹再乘2等於距離樹幹所需間隔		
變數意義舉例驗證:n=高度
				 a=層數
				 b=樹幹高度
				 i=當前層數
				 j=當層片數
*/