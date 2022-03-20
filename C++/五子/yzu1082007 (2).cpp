#include "pch.h"
#include <iostream>
#include <windows.h>
#include <iomanip>
#include <time.h>
using namespace std;
struct team {
	int who;
	int A[8][8];
};
struct point {
	int x;
	int y;
};
struct way {
	int times;
	point ways[60];
	way() {
		times = 0;
	}
};
const int blank = 0;
const int white = 1;
const int black = 2;
void setboard(struct team& t, struct team other) {
	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++)
			t.A[i][j] = other.A[i][j];
	t.who = other.who;
}
void findway(team t, way* w);
void change(point p, team* t);
bool still_in(int row, int col);
bool in_blank(int row, int col, int x, int y, team t);
int counting(team m, team o);
extern"C" {
	_declspec(dllexport) struct point play(struct team my_t) {
		//檔案內
		int tmp = 0;
		int ti = 0;
		int score[60] = { 0 };
		team opp_t;
		way my_w, opp_w;
		struct point p;
		findway(my_t, &my_w);
		for (int i = 0; i < my_w.times; i++) {
			p.x = my_w.ways[i].x;
			p.y = my_w.ways[i].y;
			setboard(opp_t, my_t);
			change(p, &opp_t);
			if (((p.x == 0) && (p.y == 0)) ||
				((p.x == 0) && (p.y == 7)) ||
				((p.x == 7) && (p.y == 0)) ||
				((p.x == 7) && (p.y == 7))) {
				score[i] += 1000;
			}
			else if (((p.x == 0) && (p.y == 1)) ||
				((p.x == 1) && (p.y == 0)) ||
				((p.x == 6) && (p.y == 0)) ||
				((p.x == 7) && (p.y == 1)) ||
				((p.x == 0) && (p.y == 6)) ||
				((p.x == 1) && (p.y == 7)) ||
				((p.x == 6) && (p.y == 7)) ||
				((p.x == 7) && (p.y == 6))) {
				score[i] += 20;
			}
			else if (((p.x == 0) && (p.y == 1)) ||
				((p.x == 1) && (p.y == 1)) ||
				((p.x == 1) && (p.y == 6)) ||
				((p.x == 6) && (p.y == 1)) ||
				((p.x == 6) && (p.y == 6))) {
				score[i] = 0;
			}
			else {
				score[i] += 60;
			}
			if (p.x == 0 || p.y == 0 || p.x == 7 || p.y == 7) {
				score[i] += 40;
			}
			else if (p.x == 1 || p.y == 1 || p.x == 6 || p.y == 6) {
				score[i] += 0;
			}
			else {
				score[i] += 20;
			}
			opp_w.times = 0;
			opp_t.who = (3 - my_t.who);
			findway(opp_t, &opp_w);
			score[i] += counting(my_t, opp_t) * 65;
			score[i] -= opp_w.times * 5;
			for (int k = 0; k < opp_w.times; k++) {
				if (((opp_w.ways[k].x == 0) && (opp_w.ways[k].y == 0)) ||
					((opp_w.ways[k].x == 0) && (opp_w.ways[k].y == 7)) ||
					((opp_w.ways[k].x == 7) && (opp_w.ways[k].y == 0)) ||
					((opp_w.ways[k].x == 7) && (opp_w.ways[k].y == 7))) {
					score[i] -= 100;
					break;
				}
			}
		}
		for (int i = 0; i < my_w.times; i++) {
			if (score[i] >= tmp) {
				tmp = score[i];
				ti = i;
			}
		}
		p.x = my_w.ways[ti].x;
		p.y = my_w.ways[ti].y;
		return p;
	}
}
void findway(team t, way* w) {
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			if (t.A[i][j] == blank) {
				bool could = false;
				for (int ii = -1; ii <= 1; ii++) {
					for (int jj = -1; jj <= 1; jj++) {
						if (in_blank(i, j, ii, jj, t)) {
							could = true;
						}
					}
				}
				if (could) {
					w->ways[w->times].x = i;
					w->ways[w->times].y = j;
					w->times++;
				}
			}
		}
	}
}
bool still_in(int row, int col) {
	if (row >= 0 && row < 8 && col >= 0 && col < 8) {
		return true;
	}
	return false;
}
bool in_blank(int row, int col, int x, int y, team t) {
	if (t.A[row + x][col + y] == (3 - t.who)) {
		for (int max = 2; max < 8; max++) {
			if (t.A[row + max * x][col + max * y] == blank &&
				still_in(row + max * x, col + max * y)) {
				return false;
			}
			else if (t.A[row + max * x][col + max * y] == t.who &&
				still_in(row + max * x, col + max * y)) {
				return true;
			}
		}
	}
	return false;
}
void change(point p, team* t) {
	for (int ii = -1; ii <= 1; ii++) {
		for (int jj = -1; jj <= 1; jj++) {
			if (in_blank(p.x, p.y, ii, jj, *t)) {
				t->A[p.x][p.y] = t->who;
				for (int max = 1; max < 8; max++) {
					if (t->A[p.x + max * ii][p.y + max * jj] == (3 - t->who) &&
						still_in(p.x + max * ii, p.y + max * jj)) {
						t->A[p.x + max * ii][p.y + max * jj] = t->who;
					}
					if (t->A[p.x + max * ii][p.y + max * jj] == t->who &&
						still_in(p.x + max * ii, p.y + max * jj)) {
						break;
					}
				}
			}
		}
	}
}
int counting(team m, team o) {
	int sum = 0;
	for (int i = 0; i < 8; i++) {
		for (int j = 0; j < 8; j++) {
			if (o.A[i][j] == m.who) {
				sum++;
			}
			if (m.A[i][j] == m.who) {
				sum--;
			}
		}
	}
	return sum;
}