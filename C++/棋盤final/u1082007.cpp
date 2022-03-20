#include <iostream>
#include <fstream>   
#include <string>
#include <time.h>
using namespace std;
//�Ѥl��ƪ��
struct piece {
	int id;
	int row;
	int col;
};
void input();			//Ū���ѽL
void output(int player, piece final_move);//�g�J�̨θ�
piece fill_pieces(int row, int col);//��J�Ѥl���
piece fill_other_way(int id, int row, int col);//��J��l���
int board[10][9];		 //�ѽL
int player;				//�����
int best_choose = -1;	//�P�_�̨κX�l�i�Y
int choose = 200;		//�̨ΧP�_
int class_system[16] = { 7,1,1,2,2,4,4,6,6,5,5,3,3,3,3,3 };//�X�l�����Ť��t
int num_between(piece A, piece B);//�p�����������h�ֹ��
bool be_killed;				//�O�_�Q�Ĥ�ҦY
bool canDefense_king(piece A, piece B, int i, int j);//�ۧ��묹�O�@
bool canDefense_other(piece A, piece B, int i, int j);//������
bool canMove(piece A, piece B);//�P�_�W�h
bool re_canMove(piece A, piece B);//�P�_�Ĥ�W�h(�ڤ�ˮ`)
bool kill_itself(int id, int row, int col);//����۱�
bool teammate(int moveid, int killid);//�O�_�P�}��
bool JU(piece A, piece B);//�N���W�h
bool SI(piece A, piece B);//�h���W�h
bool SHU(piece A, piece B);//�H���W�h
bool MU(piece A, piece B);//�����W�h
bool GI(piece A, piece B);//�����W�h
bool PU(piece A, piece B);//�����W�h
bool BI(piece A, piece B);//�L���W�h
piece final_move;//�̲׸�
piece move_piece;//�����Ʀs��
piece kill_piece;//���ʸ�Ʀs��
struct piece pieces[16][17] = { 0 };//�ڤ��k
struct piece re_pieces[16][17] = { 0 };//�Ĥ��k
struct piece random_way[120] = { 0 };//�H���s����k
struct piece way[120] = { 0 };//���ʫ�Ҧs������k
int main(int n, char** argv) {
	//--------�ޤJ�����-------------------------
	if (n >= 2) {
		player = atoi(argv[1]);
	}
	//--------------Ū���ѽL-----------------------
	input();
	//---------------�P�_-----------------------
	int killer = -1;
	int m = 0;
	int f = 0;
	//---------------�ڤ��k--------------------
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 9; j++) {
			move_piece = fill_pieces(i, j);										//�ڤ��m
			if (!(board[i][j] == -1) && board[i][j] / 100 == player) {
				f = 0;
				for (int r = 0; r < 10; r++) {
					for (int c = 0; c < 9; c++) {
						kill_piece = fill_pieces(r, c);							//�ڤ�i��
						if (canMove(move_piece, kill_piece)) {					//�P�_�W�h
							pieces[m][f] = fill_other_way(board[i][j], r, c);	//�g�J�B�k
							f++;
						}
					}
				}
				m++;
			}
		}
	}
	m = 0;
	//-----------------�Ĥ��k------------
	for (int i = 0; i < 10; i++) {
		for (int j = 0; j < 9; j++) {
			move_piece = fill_pieces(i, j);									//�Ĥ��m
			if (!(board[i][j] == -1) && board[i][j] / 100 == abs(player - 1)) {
				f = 0;
				for (int r = 0; r < 10; r++) {
					for (int c = 0; c < 9; c++) {
						kill_piece = fill_pieces(r, c);						//�Ĥ�i��
						if (re_canMove(move_piece, kill_piece)) {			//�P�_�W�h
							re_pieces[m][f] = fill_other_way(board[i][j], r, c);//�g�J�B�k
							f++;
						}
					}
				}
				m++;
			}
		}
	}
	//----------���N�i�H�Y�N�Y------
	for (int i = 0; i < 16; i++) {
		for (int j = 0; j < 17; j++) {
			if (board[pieces[i][j].row][pieces[i][j].col] % 100 == 0) {
				best_choose = 100;
				final_move = pieces[i][j];
			}
		}
	}
	//--------�N�����u----------------
	if (best_choose == -1) {
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 9; j++) {
				if ((board[i][j] % 100 == 0) && board[i][j] / 100 == player) {//�M��N
					be_killed = false;
					for (int k = 0; k < 16; k++) {
						for (int l = 0; l < 17; l++) {
							if (!(re_pieces[k][l].id == 0 && re_pieces[k][l].row == 0 && re_pieces[k][l].col == 0)) {
								if ((re_pieces[k][l].row == i) && (re_pieces[k][l].col == j)) {//�P�_�N�O�_�N�Q�Y
									be_killed = true;
									killer = re_pieces[k][l].id;
								}
							}
							//�P�_�O�_�i�H�����Y�����
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
								//�M��L�ѨӦu�@�N
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
								//�N��ۤv�k�]
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
	//-------------------���ĴѤ��Ƴ̰��åB�Q�Y����-------------------------
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
	//�P�_�ۤv�O�_�Q�Y
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
							//�M�䦳�L�Ѥl�i�H����Ĥ�i��Y������
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
							//�O�_�i�H�����Y���ĤH
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
								//�M��i�H����ĤH���ѨB
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
	//--------------�H���B�k--------------------------
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
		//�T�w�̲׸Ѥ��|�۱�
		for (int i = 0; i < 16; i++) {
			for (int j = 0; j < 17; j++) {
				if (!(pieces[i][j].id == 0 && pieces[i][j].row == 0 && pieces[i][j].col == 0) && kill_itself(pieces[i][j].id, pieces[i][j].row, pieces[i][j].col) == false) {
					random_way[m] = pieces[i][j];
					m++;
				}
			}
		}
		//�x�s�̲׸�
		do {
			srand(time(NULL));
			final_move = random_way[rand() % m];
		} while (final_move.id == 0 && final_move.row == 0);
	}
	//-----------------��X�ɮ�----------------------------
	output(player, final_move);
	return 1;
}
void input() {
	ifstream infile("table.txt");//��Ū���ѽL�ɮ�
	string value;
	for (int i = 0; i < 10; i++) {//Ū���C��
		for (int j = 0; j < 8; j++) {//Ū���C�C
			getline(infile, value, ' ');//�C�J��Ů氱��
			board[i][j] = atoi(value.c_str());//�N���쪺�Ȧs�Jboard��
		}
		getline(infile, value, '\n');//�C�J�촫�氱��
		board[i][8] = atoi(value.c_str());//�N���쪺�Ȧs�Jboard��
	}
}
void output(int player, piece final_move) {
	ofstream outFile;
	outFile.open("play.txt");//�}���ɮ�play.txt
	outFile << player << " " << final_move.id << " " << final_move.col << " " << final_move.row << endl;//�N(�����)(�Ѥlid)(�Ѥl���ʮy��)�g�Jplay.txt
	outFile.close();//�����ɮ�play.txt
}
int num_between(piece A, piece B) {
	int sum = 0;//�`�p��
	if ((B.row - A.row) == 0) {//���y�гB�P���
		if (B.col - A.col > 0) {//���ʳB�����y�Фj��
			for (int j = A.col + 1; j < B.col; j++) {//���L�����C�ӴѤl
				if (!(board[A.row][j] == -1)) {//�P�_�������X�����
					sum++;//���O�Ū� �`�p�[�@
				}
			}
		}
		else if (B.col - A.col < 0) {//���ʳB�����y�Фp��
			for (int j = A.col - 1; j > B.col; j--) {//���L�����C�ӴѤl
				if (!(board[A.row][j] == -1)) {//�P�_�������X�����
					sum++;//���O�Ū� �`�p�[�@
				}
			}
		}
		return sum;//�^���`�p��
	}
	if ((B.col - A.col) == 0) {//���y�гB�P�C��
		if (B.row - A.row > 0) {//���ʳB�����y�Фj��
			for (int i = A.row + 1; i < B.row; i++) {//���L�����C�ӴѤl
				if (!(board[i][A.col] == -1)) {//�P�_�������X�����
					sum++;//���O�Ū� �`�p�[�@
				}
			}
		}
		else if (B.row - A.row < 0) {//���ʳB�����y�Фp��
			for (int i = A.row - 1; i > B.row; i--) {//���L�����C�ӴѤl
				if (!(board[i][A.col] == -1)) {//�P�_�������X�����
					sum++;//���O�Ū� �`�p�[�@
				}
			}
		}
		return sum;//�^���`�p��
	}
	return -1;//�Y���B��P��P�C�^��-1
}
bool canDefense_king(piece A, piece B, int i, int j) {
	int temp, can;
	temp = board[i][j];//�s�����ʦ�mid
	board[i][j] = 200;//�N���ʳB�]�����
	can = re_canMove(A, B);//�P�_�Ĥ�i�_����
	board[i][j] = temp;//�N���ʳB�]�����
	return can;//�^�ǬO�_���m
}
bool canDefense_other(piece A, piece B, int i, int j) {
	int temp, can;
	board[A.row][A.col] = 200;//�N���ʳB�]�����
	temp = board[i][j];//�x�s�����mid
	board[i][j] = -1;//�����m�]����
	can = re_canMove(A, B);//�P�_�O�_�Q�Y
	board[A.row][A.col] = -1;//���ʫ��m�٭��
	board[i][j] = temp;//���ʫ��m�٭�id
	return can;//�^�ǥi�_���m
}
bool canMove(piece A, piece B) {
	if (B.id == -1 || !teammate(A.id, B.id)) {//�P�_�O�_���D�ڤ�Ѥl
		switch (A.id % 100) {//�Nid��²��0-15
		case 0:
			return JU(A, B);//�N�W�h
			break;
		case 1:
		case 2:
			return SI(A, B);//�h�W�h
			break;
		case 3:
		case 4:
			return SHU(A, B);//�H�W�h
			break;
		case 5:
		case 6:
			return GI(A, B);//���W�h
			break;
		case 7:
		case 8:
			return MU(A, B);//���W�h
			break;
		case 9:
		case 10:
			return PU(A, B);//���W�h
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			return BI(A, B);//�L�W�h
			break;
		}
	}
	return false;//�Y�D�^�ǧ_
}
bool re_canMove(piece A, piece B) {
	switch (A.id % 100) {//�Nid��²��0-15
	case 0:
		return JU(A, B);//�N�W�h
		break;
	case 1:
	case 2:
		return SI(A, B);//�h�W�h
		break;
	case 3:
	case 4:
		return SHU(A, B);//�H�W�h
		break;
	case 5:
	case 6:
		return GI(A, B);//���W�h
		break;
	case 7:
	case 8:
		return MU(A, B);//���W�h
		break;
	case 9:
	case 10:
		return PU(A, B);//���W�h
		break;
	case 11:
	case 12:
	case 13:
	case 14:
	case 15:
		return BI(A, B);//�L�W�h
		break;
	}
	return false;//�Y�D�^�ǧ_
}
bool teammate(int moveid, int killid) {
	if (moveid / 100 == killid / 100) {//�P�_��ѬO�_���P��
		return true;//�O�^�ǬO
	}
	return false;//�D�^�ǫD
}
bool JU(piece A, piece B) {
	//������
	if (B.id % 100 == 0 && A.col == B.col) {
		if (num_between(A, B) == 0)
			return true;
	}
	//�����
	if (B.row >= 0 && B.row <= 2 && B.col >= 3 && B.col <= 5) {
		if ((abs(B.row - A.row) == 1 && abs(B.col - A.col) == 0) || (abs(B.row - A.row) == 0 && abs(B.col - A.col) == 1)) {
			return true;
		}
	}
	//����
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
	//�����
	if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
		//���ʰϤ��W�V����d��
		if (B.row >= 0 && B.row <= 4 && B.col >= 0 && B.col <= 8) {
			//�Y�k�U�@�L��Ѷ}��k�U�貾�ʦ�m
			if (board[A.row + 1][A.col + 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == 2) {
					return true;
				}
			}
			//�Y���U�@�L��Ѷ}�񥪤U�貾�ʦ�m
			if (board[A.row + 1][A.col - 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == -2) {
					return true;
				}
			}
			//�Y�k�W�@�L��Ѷ}��k�W�貾�ʦ�m
			if (board[A.row - 1][A.col + 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == 2) {
					return true;
				}
			}
			//�Y���W�@�L��Ѷ}�񥪤W�貾�ʦ�m
			if (board[A.row - 1][A.col - 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == -2) {
					return true;
				}
			}
		}
	}
	//����
	else if (A.row >= 5 && A.row <= 9 && A.col >= 0 && A.col <= 8) {
		//���ʰϤ��W�V����d��
		if ((B.row >= 5 && B.row <= 9 && B.col >= 0 && B.col <= 8)) {
			//�Y�k�U�@�L��Ѷ}��k�U�貾�ʦ�m
			if (board[A.row + 1][A.col + 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == 2) {
					return true;
				}
			}
			//�Y���U�@�L��Ѷ}�񥪤U�貾�ʦ�m
			if (board[A.row + 1][A.col - 1] == -1) {
				if (B.row - A.row == 2 && B.col - A.col == -2) {
					return true;
				}
			}
			//�Y�k�W�@�L��Ѷ}��k�W�貾�ʦ�m
			if (board[A.row - 1][A.col + 1] == -1) {
				if (B.row - A.row == -2 && B.col - A.col == 2) {
					return true;
				}
			}
			//�Y���W�@�L��Ѷ}�񥪤W�貾�ʦ�m
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
	//�Y�U�@�L��Ѷ}��U�貾�ʦ�m
	if (board[A.row + 1][A.col] == -1) {
		if (B.row - A.row == 2 && abs(B.col - A.col) == 1) {
			return true;
		}
	}
	//�Y�W�@�L��Ѷ}��W�貾�ʦ�m
	if (board[A.row - 1][A.col] == -1) {
		if (B.row - A.row == -2 && abs(B.col - A.col) == 1) {
			return true;
		}
	}
	//�Y�k�@�L��Ѷ}��k�貾�ʦ�m
	if (board[A.row][A.col + 1] == -1) {
		if (abs(B.row - A.row) == 1 && B.col - A.col == 2) {
			return true;
		}
	}
	//�Y���@�L��Ѷ}�񥪤貾�ʦ�m
	if (board[A.row][A.col - 1] == -1) {
		if (abs(B.row - A.row) == 1 && B.col - A.col == -2) {
			return true;
		}
	}
	return false;
}
bool GI(piece A, piece B) {
	//�p�⤤���O�_�����
	if (num_between(A, B) == 0) {
		return true;
	}
	return false;
}
bool PU(piece A, piece B) {
	//�p��O�n���٬O�n����
	if ((num_between(A, B) == 0 && B.id == -1) || (num_between(A, B) == 1) && !(B.id == -1)) {
		return true;
	}
	return false;
}
bool BI(piece A, piece B) {
	//�����
	if (A.id / 100 == 0) {
		//�L�e�e
		if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
			if ((B.row - A.row) == 1 && (B.col - A.col) == 0) {
				return true;
			}
		}
		//�L�e��
		if (A.row >= 5 && A.row <= 9 && A.col >= 0 && A.col <= 8) {
			if (((B.row - A.row) == 1) && (abs(B.col - A.col) == 0) || (abs(B.col - A.col) == 1) && ((B.row - A.row) == 0)) {
				return true;
			}
		}
		return false;
	}
	//����
	if (A.id / 100 == 1) {
		//�L�e��
		if (A.row >= 0 && A.row <= 4 && A.col >= 0 && A.col <= 8) {
			if (((B.row - A.row) == -1) && (abs(B.col - A.col) == 0) || (abs(B.col - A.col) == 1) && ((B.row - A.row) == 0)) {
				return true;
			}
		}
		//�L�e�e
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
	//�M�������ʦ�m
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
	//�s�����ʫe��id,�ñN�ѽL�]�����ʫ�
	temp = board[row][col];
	board[row][col] = id;
	board[x][y] = -1;
	f = 0;
	//�p�Ⲿ�ʫ�ѽL�ĤH�ҥi����m
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
	//�M�䦳�L�Ĥ�B�k�i�N�ڤ�N��Y��
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
	//�^�_�쪬�æ^��false
	board[row][col] = temp;
	board[x][y] = id;
	return false;
}
piece fill_pieces(int row, int col) {//���w��e�y�ж�J��T
	piece pieces;
	pieces.id = board[row][col];
	pieces.row = row;
	pieces.col = col;
	return pieces;
}
piece fill_other_way(int id, int row, int col) {//��J�S�w��T
	piece way;
	way.id = id;
	way.row = row;
	way.col = col;
	return way;
}