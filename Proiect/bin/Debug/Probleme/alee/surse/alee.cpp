#include <fstream>

/**
* Sursa a luat 100 puncte pe campion.edu
*/
using namespace std;

ofstream fout("alee.out");

struct axe {
	int x,y;
};

// punct inceput si sfarsit
axe inceput, final, c[31000], aux;

void citire();
void afisare();
void bordare();
void lee();

int n, m, p[177][177];
// definesc directiile de deplasare, sus, jos, stanga, dreapta pe axele ox si oy
int dx[4] = {1, -1, 0,  0};
int dy[4] = {0,  0, 1, -1};

int main() {
	citire();	
	bordare(); // maticea trebuie bordata ca sa nu ies din ea, cu -2, obstacol
	lee();
	
	//afisare();
}

void lee() {
	// construiesc vectorul coada	
	/*
	@ st = indicele care poate fi extras din coada
	@ dr = indicele care poate fi adaugat in coada
	*/
	// pun primul element in coada
	long long st, dr;
	st = 1;
	dr = 1;	
	
	// pozitia initiala
	c[1].x = inceput.x;
	c[1].y = inceput.y;
	
	// pozitiile temporare pe care am sa fiu in functie de i, folosite la linia 62
	int xi = 0, yi = 0;
	
	// notez cu 1 prima pozitie pentru ca am trecut pe acolo
	p[inceput.x][inceput.y] = 1;
	
	// cat timp nu am umplut stiva, mai am de numerotat prin matrice
	while(st <= dr) {
		// scot ultimul element din coada, stiva, si il pun intr-o variabila temporara aux
		// in aux au sa fie copiate valorile curente din coada
		aux = c[st];
		
		// pentru fiecare vecini ai lui aux, ii numerotez, luand valoare 'aux + 1'
		// merg pe cele 4 pozitii in matrice, sus, jos, stanga dreapta, folosindu-ma de vectorii dx si dy
		for(int i=0;i<4;i++) {
			// pentru fiecare pozitie noua ma deplasez numai daca nu este copac, adica valoarea -2
			// cum am bordat matricea inainte, nu mai e pericolul sa iasa din ea
			xi = aux.x + dx[i];
			yi = aux.y + dy[i];
			
			// daca pozitia pe care am trecut nu e obstacol
			if(p[xi][yi] == 0) {
				// am gasit o pozitie buna
				// maresc indicele pe care se va adauga in stiva in viitor
				dr++;
				c[dr].x = xi;
				c[dr].y = yi;
				
				// numerotez pozitia curenta, cu valoarea pozitiei anterioare + 1
				p[xi][yi] = p[aux.x][aux.y]+1;
			}			
		}
		// maresc indicele  care se va scoate din coada in viitor
		st++;
		
	}
	
	// daca a gasit un drum, inseamna ca pozitia finala va fi diferita de 0
	if(p[final.x][final.y] != 0) 
		fout<<p[final.x][final.y]<<" ";
	else // inseamna ca nu exista un drum, e blocat de copaci - obstacole
		fout<<"Nu exista drum minim!";
}

void citire() {
	ifstream fin("alee.in");
	fin>>n>>m;
	// adaug copacii in matrice, pe aici nu se trece, notez cu -2
	axe copac;
	for(int i=1;i<=m;i++) {
		fin>>copac.x>>copac.y;
		p[copac.x][copac.y] = -2;
	}
	// pozitiile de final si inceput
	fin>>inceput.x>>inceput.y;
	fin>>final.x>>final.y;
	fin.close();
}

void bordare() {
	// bordez matricea cu obstacol -2
	
	for(int i=0; i<=n+1;i++) {
		// bordez pereta la stanga si la dreapta
		p[i][0] = p[i][n+1] = -2;
		// pretele de sus si jos
		p[0][i] = p[n+1][i] = -2;
	}
}
