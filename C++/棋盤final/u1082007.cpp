#include <iostream>
#include <fstream>   
#include <string>
#include <time.h>
using namespace std;
//棋子資料表格
struct piece {
	int id;
	int row;
	int col;
};
void input();			//讀取棋盤
void output(int player, piece final_move);//寫入最佳解
piece fill_pieces(int row, int col);//填入棋子資料
piece fill_other_way(int id, int row, int col);//填入其餘資料
int board[10][9];		 //棋盤
int player;				//先後手
int best_choose = -1;	//判斷最佳旗子可吃
int choose = 200;		//最佳判斷
int class_system[16] = { 7,1,1,2,2,4,4,6,6,5,5,3,3,3,3,3 };//旗子的階級分配
int num_between(piece A, piece B);//計算兩期之間有多少實棋
bool be_killed;				//是否被敵方所吃
bool canDefense_king(piece A, piece B, int i, int j);//自我犧牲保護
bool canDefense_other(piece A, piece B, int i, int j);//封鎖對方
bool canMove(piece A, piece B);//判斷規則
bool re_canMove(piece A, piece B);//判斷敵方規則(我方傷害)
bool kill_itself(int id, int row, int col);//防止自殺
bool teammate(int moveid, int killid);//是否同陣營
bool JU(piece A, piece B);//將的規則
bool SI(piece A, piece B);//士的規則
bool SHU(piece A, piece B);//象的規則
bool MU(piece A, piece B);//馬的規則
bool GI(piece A, piece B);//車的規則
bool PU(piece A, piece B);//炮的規則
bool BI(piece A, piece B);//兵的規則
piece final_move;//最終解
piece move_piece;//原先資料存取
piece kill_piece;//移動資料存取
struct piece pieces[16][17] = { 0 };//我方方法
struct piece re_pieces[16][17] = { 0 };//敵方方法
struct piece random_way[120] = { 0 };//隨機存取方法
struct piece way[120] = { 0 };//移動後所存取之方法
int main(int n, char** argv) {
	//--------引入先後手-------------------------
	if (n >= 2) {
		player = atoi(argv[1]);
	}
	//--------------讀取棋盤-----------------------
	input();
	//---------------判斷-----------------------
	int killer = -1;
	int m = 0;
	int f = 0;
	//---------------我方方法--------------------
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 9; j++) {
			move_piece = fill_pieces(i, j);										//我方位置
			if (!(board[i][j] == -1) && board[i][j] / 100 == player) {
				f = 0;
				for (int r = 0; r < 10; r++) {
					for (int c = 0; c < 9; c++) {
						kill_piece = fill_pieces(r, c);							//我方可走
						if (canMove(move_piece, kill_piece)) {					//判斷規則
							pieces[m][f] = fill_other_way(board[i][j], r, c);	//寫入步法
							f++;
						}
					}
				}
				m++;
			}
		}
	}
	m = 0;
	//-----------------敵方方法------------
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 9; j++) {
			move_piece = fill_pieces(i, j);									//敵方位置
			if (!(board[i][j] == -1) && board[i][j] / 100 == abs(player - 1)) {
				f = 0;
				for (int r = 0; r < 10; r++) {
					for (int c = 0; c < 9; c++) {
						kill_piece = fill_pieces(r, c);						//敵方可走
						if (re_canMove(move_piece, kill_piece)) {			//判斷規則
							re_pieces[m][f] = fill_other_way(board[i][j], r, c);//寫入步法
							f++;
						}
					}
				}
				m++;
			}
		}
	}
	//----------有將可以吃就吃------
	for (int i = 0; i < 16; i++) {
		for (int j = 0; j < 17; j++) {
			if (board[pieces[i][j].row][pieces[i][j].col] % 100 == 0) {
				best_choose = 100;
				final_move = pieces[i][j];
			}
		}
	}
	//--------將的防守----------------
	if (best_choose == -1) {
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 9; j++) {
				if ((board[i][j] % 100 == 0) && board[i][j] / 100 == player) {//尋找將
					be_killed = false;
					for (int k = 0; k < 16; k++) {
						for (int l = 0; l < 17; l++) {
							if (!(re_pieces[k][l].id == 0 && re_pieces[k][l].row == 0 && re_pieces[k][l].col == 0)) {
								if ((re_pieces[k][l].row == i) && (re_pieces[k][l].col == j)) {//判斷將是否將被吃
									be_killed = true;
									killer = re_pieces[k][l].id;
								}
							}
							//判斷是否可以直接吃掉對方
							if (be_killed == true) {
								for (int m = 0; m < 16; m++) {
									for (int o = 0; o < 17; o++) {
										if (!(pieces[m][o].id == 0 && pieces[m][o].row == 0 && pieces[m][o].col == 0)) {
											if (board[pieces[m][o].row][pieces[m][o].col] == killer) {
												if (kill_itself(pieces[m][o].id, pieces[m][o].row, pieces[m][o].col) == false) {
													best_choose = 100;
													final_move = fill_other_way(pieces[m][o].id, pieces[m][o].row, pieces[m][o].col);
												}
											}
										}
									}
								}
								//尋找他棋來守護將
								if (best_choose == -1) {
									for (int p = 0; p < 16; p++) {
										for (int q = 0; q < 17; q++) {
											if (!(pieces[p][q].id == 0 && pieces[p][q].row == 0 && pieces[p][q].col == 0)) {
												kill_piece = fill_pieces(i, j);
												for (int i = 0; i < 10; i++) {
													for (int j = 0; j < 9; j++) {
														if (board[i][j] == killer)
															move_piece = fill_pieces(i, j);
													}
												}
												if (canDefense_king(move_piece, kill_piece, pieces[p][q].row, pieces[p][q].col) == false && choose > class_system[pieces[p][q].id % 100]&& kill_itself(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col) == false) {
													best_choose = 100;
													choose = class_system[pieces[p][q].id % 100];
													final_move = fill_other_way(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col);
												}
											}
										}
									}
								}
								//將領自己逃跑
								if (best_choose == -1) {
									for (int p = 0; p < 16; p++) {
										if(pieces[p][0].id%100==0){
											for(int q=0;q<17;q++){
												if (!(pieces[p][q].row == 0 && pieces[p][q].col == 0)&& kill_itself(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col) == false) {
													best_choose = 100;
													final_move = fill_other_way(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	//-------------------有敵棋分數最高並且被吃掉的-------------------------
	if (best_choose == -1) {
		for (int i = 0; i < 16; i++) {
			for (int j = 0; j < 17; j++) {
				if (!(pieces[i][j].id == 0 && pieces[i][j].row == 0 && pieces[i][j].col == 0)) {
					if ((class_system[board[pieces[i][j].row][pieces[i][j].col]] >= best_choose) && !(board[pieces[i][j].row][pieces[i][j].col] == -1)) {
						be_killed = false;
						for (int k = 0; k < 16; k++) {
							for (int l = 0; l < 17; l++) {
								if (!(re_pieces[k][l].id == 0 && re_pieces[k][l].row == 0 && re_pieces[k][l].col == 0)) {
									if ((re_pieces[k][l].row == pieces[i][j].row) && (re_pieces[k][l].col == pieces[i][j].col)) {
										be_killed = true;
										break;
									}
								}
							}
						}
						if (be_killed == false && kill_itself(pieces[i][j].id, pieces[i][j].row, pieces[i][j].col) == false) {
							best_choose = class_system[board[pieces[i][j].row][pieces[i][j].col]];
							final_move = fill_other_way(pieces[i][j].id, pieces[i][j].row, pieces[i][j].col);
						}
					}
				}
			}
		}
	}
	//判斷自己是否被吃
	if (best_choose == -1) {
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 9; j++) {
				if (board[i][j] / 100 == player) {\
					be_killed = false;
					for (int k = 0; k < 16; k++) {
						for (int l = 0; l < 17; l++) {
							if (!(re_pieces[k][l].id == 0 && re_pieces[k][l].row == 0 && re_pieces[k][l].col == 0)) {
								if ((re_pieces[k][l].row == i) && (re_pieces[k][l].col == j)) {\
									be_killed = true;
									killer = re_pieces[k][l].id;
								}
							}
							//尋找有無棋子可以封鎖敵方進攻若有不動
							if (be_killed == true) {
								for (int p = 0; p < 16; p++) {
									for (int q = 0; q < 17; q++) {
										kill_piece = fill_pieces(i, j);
										if (re_canMove(pieces[p][q], kill_piece)) {
											be_killed = false;
										}
									}
								}
							}
							//是否可以直接吃掉敵人
							if (be_killed == true) {
								for (int m = 0; m < 16; m++) {
									for (int o = 0; o < 17; o++) {
										if (!(pieces[m][o].id == 0 && pieces[m][o].row == 0 && pieces[m][o].col == 0)) {
											if (board[pieces[m][o].row][pieces[m][o].col] == killer && kill_itself(pieces[m][o].id, pieces[m][o].row, pieces[m][o].col) == false) {
												best_choose = 100;
												final_move = fill_other_way(pieces[m][o].id, pieces[m][o].row, pieces[m][o].col);
											}
										}
									}
								}
								//尋找可以封鎖敵人的棋步
								if (best_choose == -1) {
									for (int p = 0; p < 16; p++) {
										for (int q = 0; q < 17; q++) {
											if (!(pieces[p][q].id == 0 && pieces[p][q].row == 0 && pieces[p][q].col == 0)) {
												kill_piece = fill_pieces(i, j);
												move_piece = fill_other_way(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col);
												for (int i = 0; i < 10; i++) {
													for (int j = 0; j < 9; j++) {
														if (board[i][j] == pieces[p][q].id) {
															if (canDefense_other(move_piece, kill_piece, i, j) == true && kill_itself(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col) == false) {
																best_choose = 100;
																final_move = fill_other_way(pieces[p][q].id, pieces[p][q].row, pieces[p][q].col);
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	//--------------隨機步法--------------------------
	if (best_choose == -1) {
		for (int i = 0; i < 16; i++) {
			for (int j = 0; j < 17; j++) {
				for (int x = 0; x < 16; x++) {
					for (int y = 0; y < 17; y++) {
						if (pieces[i][j].row == re_pieces[x][y].row&&pieces[i][j].col == re_pieces[x][y].col) {
							pieces[i][j] = fill_other_way(0, 0, 0);
						}
					}
				}
			}
		}
		m = 0;
		//確定最終解不會自殺
		for (int i = 0; i < 16; i++) {
			for (int j = 0; j < 17; j++) {
				if (!(pieces[i][j].id == 0 && pieces[i][j].row == 0 && pieces[i][j].col == 0) && kill_itself(pieces[i][j].id, pieces[i][j].row, pieces[i][j].col) == false) {
					random_way[m] = pieces[i][j];
					m++;
				}
			}
		}
		//儲存最終解
		do {
			srand(time(NULL));
			final_move = random_way[rand() % m];
		} while (final_move.id == 0 && final_move.row == 0);
	}
	//-----------------輸出檔案----------------------------
	output(player, final_move);
	return 1;
}
void input() {
	ifstream infile("table.txt");//先讀取棋盤檔案
	string value;
	for (int i = 0; i < 10; i++) {//讀取每行
		for (int j = 0; j < 8; j++) {//讀取每列
			getline(infile, value, ' ');//每遇到空格停止
			board[i][j] = atoi(value.c_str());//將掃到的值存入board內
		}
		getline(infile, value, '\n');//每遇到換行停止
		board[i][8] = atoi(value.c_str());//將掃到的值存入board內
	}
}
void output(int player, piece final_move) {
	ofstream outFile;
	outFile.open("play.txt");//開啟檔案play.txt
	outFile << player << " " << final_move.id << " " << final_move.col << " " << final_move.row << endl;//將(先後手)(棋子id)(棋子移動座標)寫入play.txt
	outFile.close();//關閉檔案play.txt
}
int num_between(piece A, piece B) {
	int sum = 0;//總計值
	if ((B.row - A.row) == 0) {//當兩座標處同行時
		if (B.col - A.col > 0) {//當移動處比原先座標大時
			for (int j = A.col + 1; j < B.col; j++) {//掃過之間每個棋子
				if (!(board[A.row][j] == -1)) {//判斷中間有幾顆實棋
					sum++;//當不是空的 總計加一
				}
			}
		}
		else if (B.col - A.col < 0) {//當移動處比原先座標小時
			for (int j = A.col - 1; j > B.col; j--) {//掃過之間每個棋子
				if (!(board[A.row][j] == -1)) {//判斷中間有幾顆實棋
					sum++;//當不是空的 總計加一
				}
			}
		}
		return sum;//回傳總計值
	}
	if ((B.col - A.col) == 0) {//當兩座標處同列時
		if (B.row - A.row > 0) {//當移動處比原先座標大時
			for (int i = A.row + 1; i < B.row; i++) {//掃過之間每個棋子
				if (!(board[i][A.col] == -1)) {//判斷中間有幾顆實棋
					sum++;//當不是空的 總計加一
				}
			}
		}
		else if (B.row - A.row < 0) {//當移動處比原先座標小時
			for (int i = A.row - 1; i > B.row; i--) {//掃過之間每個棋子
				if (!(board[i][A.col] == -1)) {//判斷中間有幾顆實棋
					sum++;//當不是空的 總計加一
				}
			}
		}
		return sum;//回傳總計值
	}
	return -1;//若不處於同行同列回傳-1
}
bool canDefense_king(piece A, piece B, int i, int j) {
	int temp, can;
	temp = board[i][j];//存取移動位置id
	board[i][j] = 200;//將移動處設為實棋
	can = re_canMove(A, B);//判斷敵方可否移動
	board[i][j] = temp;//將移動處設為原值
	return can;//回傳是否防禦
}
bool canDefense_other(piece A, piece B, int i, int j) {
	int temp, can;
	board[A.row][A.col] = 200;//將移動處設為實棋
	temp = board[i][j];//儲存原先位置id
	board[i][j] = -1;//原先位置設為空
	can = re_canMove(A, B);//判斷是否被吃
	board[A.row][A.col] = -1;//移動後位置還原空
	board[i][j] = temp;//移動後位置還原id
	return can;//回傳可否防禦
}
bool canMove(piece A, piece B) {
	if (B.id == -1 || !teammate(A.id, B.id)) {//判斷是否為非我方棋子
		switch (A.id % 100) {//將id化簡為0-15
		case 0:
			return JU(A, B);//將規則
			break;
		case 1:
		case 2:
			return SI(A, B);//士規則
			break;
		case 3:
		case 4:
			return SHU(A, B);//象規則
			break;
		case 5:
		case 6:
			return GI(A, B);//車規則
			break;
		case 7:
		case 8:
			return MU(A, B);//馬規則
			break;
		case 9:
		case 10:
			return PU(A, B);//砲規則
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			return BI(A, B);//兵規則
			break;
		}
	}
	return false;//若非回傳否
}
bool re_canMove(piece A, piece B) {
	switch (A.id % 100) {//將id化簡為0-15
	case 0:
		return JU(A, B);//將規則
		break;
	case 1:
	case 2:
		return SI(A, B);//士規則
		break;
	case 3:
	case 4:
		return SHU(A, B);//象規則
		break;
	case 5:
	case 6:
		return GI(A, B);//車規則
		break;
	case 7:
	case 8:
		return MU(A, B);//馬規則
		break;
	case 9:
	case 10:
		return PU(A, B);//砲規則
		break;
	case 11:
	case 12:
	case 13:
	case 14:
	case 15:
		return BI(A, B);//兵規則
		break;
	}
	return false;//若非回傳否
}
bool teammate(int moveid, int killid) {
	if (moveid / 100 == killid / 100) {//判斷兩棋是否為同國
		return true;//是回傳是
	}
	return false;//非回傳非
}
bool JU(piece A, piece B) {
	//王見王
	if (B.id % 100 == 0 && A.col == B.col) {
		if (num_between(A, B) == 0)
			return true;
	}
	//先手方
	if (B.row >= 0 && B.row <= 2 && B.col >= 3 && B.col <= 5) {
		if ((abs(B.row - A.row) == 1 && abs(B.col - A.col) == 0) || (abs(B.row - A.row) == 0 && abs(B.col - A.col) == 1)) {
			return true;
		}
	}
	//後手方
	else if (B.row >= 7 && B.row <= 9 && B.col >= 3 && B.col <= 5) {
		if ((abs(B.row - A.row) == 1 && abs(B.col - A.col) == 0) || (abs(B.row - A.row) == 0 && abs(B.col - A.col) == 1)) {
			return true;
		}
	}

	return false;
}
bool SI(piece A, piece B) {
	if (B.row >= 0 && B.row <= 3 && B.col >= 3 && B.col <= 5) {
		if ((abs(B.row - A.row) == 1 && abs(B.col - A.col) == 1) || (abs(B.row - A.row) == 1 && abs(B.col - A.col) == 1)) {
			return true;
		}
	}
	else if (B.row >= 7 && B.row <= 9 && B.col >= 3 && B.col <= 5) {
		if ((abs(B.row - A.row) == 1 && abs(B.col - A.col) == 1) || (abs(B.row - A.row) == 1 && abs(B.col - A.col) == 1)) {
			return true;
		}
	}
	return false;
}
bool SHU(piece A, piece B) {
	//先手方
	if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
		//移動區不超越先制範圍
		if (B.row >= 0 && B.row <= 4 && B.col >= 0 && B.col <= 8) {
			//若右下一無實棋開放右下方移動位置
			if (board[A.row + 1][A.col + 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == 2) {
					return true;
				}
			}
			//若左下一無實棋開放左下方移動位置
			if (board[A.row + 1][A.col - 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == -2) {
					return true;
				}
			}
			//若右上一無實棋開放右上方移動位置
			if (board[A.row - 1][A.col + 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == 2) {
					return true;
				}
			}
			//若左上一無實棋開放左上方移動位置
			if (board[A.row - 1][A.col - 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == -2) {
					return true;
				}
			}
		}
	}
	//後手方
	else if (A.row >= 5 && A.row <= 9 && A.col >= 0 && A.col <= 8) {
		//移動區不超越先制範圍
		if ((B.row >= 5 && B.row <= 9 && B.col >= 0 && B.col <= 8)) {
			//若右下一無實棋開放右下方移動位置
			if (board[A.row + 1][A.col + 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == 2) {
					return true;
				}
			}
			//若左下一無實棋開放左下方移動位置
			if (board[A.row + 1][A.col - 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == -2) {
					return true;
				}
			}
			//若右上一無實棋開放右上方移動位置
			if (board[A.row - 1][A.col + 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == 2) {
					return true;
				}
			}
			//若左上一無實棋開放左上方移動位置
			if (board[A.row - 1][A.col - 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == -2) {
					return true;
				}
			}
		}
	}
	return false;
}
bool MU(piece A, piece B) {
	//若下一無實棋開放下方移動位置
	if (board[A.row + 1][A.col] == -1) {
		if (B.row - A.row == 2 && abs(B.col - A.col) == 1) {
			return true;
		}
	}
	//若上一無實棋開放上方移動位置
	if (board[A.row - 1][A.col] == -1) {
		if (B.row - A.row == -2 && abs(B.col - A.col) == 1) {
			return true;
		}
	}
	//若右一無實棋開放右方移動位置
	if (board[A.row][A.col + 1] == -1) {
		if (abs(B.row - A.row) == 1 && B.col - A.col == 2) {
			return true;
		}
	}
	//若左一無實棋開放左方移動位置
	if (board[A.row][A.col - 1] == -1) {
		if (abs(B.row - A.row) == 1 && B.col - A.col == -2) {
			return true;
		}
	}
	return false;
}
bool GI(piece A, piece B) {
	//計算中間是否有實棋
	if (num_between(A, B) == 0) {
		return true;
	}
	return false;
}
bool PU(piece A, piece B) {
	//計算是要飛還是要平移
	if ((num_between(A, B) == 0 && B.id == -1) || (num_between(A, B) == 1) && !(B.id == -1)) {
		return true;
	}
	return false;
}
bool BI(piece A, piece B) {
	//先手方
	if (A.id / 100 == 0) {
		//過河前
		if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
			if ((B.row - A.row) == 1 && (B.col - A.col) == 0) {
				return true;
			}
		}
		//過河後
		if (A.row >= 5 && A.row <= 9 && A.col >= 0 && A.col <= 8) {
			if (((B.row - A.row) == 1) && (abs(B.col - A.col) == 0) || (abs(B.col - A.col) == 1) && ((B.row - A.row) == 0)) {
				return true;
			}
		}
		return false;
	}
	//後手方
	if (A.id / 100 == 1) {
		//過河後
		if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
			if (((B.row - A.row) == -1) && (abs(B.col - A.col) == 0) || (abs(B.col - A.col) == 1) && ((B.row - A.row) == 0)) {
				return true;
			}
		}
		//過河前
		if (A.row >= 5 && A.row <= 9 && A.col >= 0 && A.col <= 8) {
			if ((B.row - A.row) == -1 && (B.col - A.col) == 0) {
				return true;
			}
		}
		return false;
	}
	else return false;
}
bool kill_itself(int id, int row, int col) {
	int x, y,f,temp;
	//尋找原先移動位置
	for ( int i = 0; i < 10; i++) {
		for ( int j = 0; j < 9; j++) {
			if (id == board[i][j]) {
				x = i;
				y = j;
			}
			if (id == board[i][j]) {
				x = i;
				y = j;
			}
		}
	}
	//存取移動前後id,並將棋盤設為移動後
	temp = board[row][col];
	board[row][col] = id;
	board[x][y] = -1;
	f = 0;
	//計算移動後棋盤敵人所可走位置
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 9; j++) {
			move_piece = fill_pieces(i, j);									
			if (!(board[i][j] == -1) && board[i][j] / 100 == abs(player - 1)) {
				for (int r = 0; r < 10; r++) {
					for (int c = 0; c < 9; c++) {
						kill_piece = fill_pieces(r, c);						
						if (re_canMove(move_piece, kill_piece)) {		
							way[f] = fill_other_way(board[i][j], r, c);
							f++;
						}
					}
				}
			}
		}
	}
	//尋找有無敵方步法可將我方將領吃掉
	for (int i = 0; i < f; i++) {
		if (player==0&&board[way[i].row][way[i].col] ==  0) {
			board[row][col] = temp;
			board[x][y] = id;
			return true;
		}
		if (player == 1 && board[way[i].row][way[i].col] == 100) {
			board[row][col] = temp;
			board[x][y] = id;
			return true;
		}
	}
	//回復原狀並回傳false
	board[row][col] = temp;
	board[x][y] = id;
	return false;
}
piece fill_pieces(int row, int col) {//指定當前座標填入資訊
	piece pieces;
	pieces.id = board[row][col];
	pieces.row = row;
	pieces.col = col;
	return pieces;
}
piece fill_other_way(int id, int row, int col) {//填入特定資訊
	piece way;
	way.id = id;
	way.row = row;
	way.col = col;
	return way;
}