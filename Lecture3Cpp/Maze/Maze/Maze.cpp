#include <iostream>
using namespace std;

typedef enum { wood, stone } material;
typedef struct {
	int x, y;
	bool isWall;
	material type;
}field;

typedef struct {
	int x, y;
}Player;

#define n 16
#define m 12
field playground[m][n];

Player player1;

void fPlaygroundInit() {
	for (int i = 0; i < m; i++) {
		for (int j = 0; j < n; j++) {
			playground[i][j].x = i;
			playground[i][j].y = j;
			playground[i][j].isWall = (i == 0 || i == (m - 1) || (i == 0 && j != 3) || j == (n - 1) || j == 0);
			if (playground[i][j].isWall && !(i == 0 && j == 3))
				playground[i][j].type = stone;
			else
				playground[i][j].type = wood;
		}
	}

}

Player fChangePlayerState(Player p1, Player p1Next) {
	if (playground[p1Next.y][p1Next.x].type != stone)
		return p1Next;
	else
		return p1;
}

void fShowMaze(Player p1) {
	if (p1.x == 3 && p1.y == 0)
		cout << "Congratulations!" << endl;
	else 
		for (int i = 0; i < m; i++) {
			for (int j = 0; j < n; j++) {
				//if (i == 0 || i == m - 1)
				//	cout << '*';
				//else 
				//	if (j == 0 || j == n - 1)
				//		cout << '*';
				//	else
				//		cout << ' ';

				if (playground[i][j].type == stone)
					cout << '*';
				else
					if (j == p1.x && i == p1.y)
						cout << '0';
					else
						cout << ' ';
			}
			cout << endl;
		}
}
int main() {
	player1.x = player1.y = 5;
	fPlaygroundInit();
	fShowMaze(player1);
	char MOVEORDER; 

	while (scanf_s(" %c", &MOVEORDER) && !(player1.x == 3 && player1.y == 0)) {
		Player TEMP = player1;
		if (MOVEORDER == 'l') {
			TEMP.x -= 1;
			player1 = fChangePlayerState(player1,TEMP);
			fShowMaze(player1);
		} else if (MOVEORDER == 'r') {
			TEMP.x += 1;
			player1 = fChangePlayerState(player1,TEMP);
			fShowMaze(player1);
		}
		else if (MOVEORDER == 'u') {
			TEMP.y -= 1;
			player1 = fChangePlayerState(player1,TEMP);
			fShowMaze(player1);
		}
		else if (MOVEORDER == 'd') {
			TEMP.y += 1;
			player1 = fChangePlayerState(player1,TEMP);
			fShowMaze(player1);
		}
		else if (MOVEORDER == 'q')
			break;
		else
			break;
	}


}