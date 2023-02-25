#include<iostream>
#include<cmath>
using namespace std;

class Square {
protected:
    int x1, y1, x2, y2, x3, y3, x4,  y4;
public:
    Square() {
        cout << "Square()" << endl;
        x1 = x2 = x3 = x4 = y1 = y2 = y3 = y4 = 0;
    }
    Square(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) {
        cout << "Square(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)" << endl;
        this->x1 = x1; this->y1 = y1;
        this->x2 = x2; this->y2 = y2;
        this->x3 = x3; this->y3 = y3;
        this->x4 = x4; this->y4 = y4;
    }
    Square(const Square& sq) {
        cout << "Square(const Square& sq)" << endl;
        x1 = sq.x1; y1 = sq.y1;
        x2 = sq.x2; y2 = sq.y2;
        x3 = sq.x3; y3 = sq.y3;
        x4 = sq.x4; y4 = sq.y4;
    }
    bool isSquare() {
        return (sqrt(abs(x1 - x2) + abs(y1 - y2)) == sqrt(abs(x1 - x4) + abs(y1 - y4)))
            && (sqrt(abs(x1 - x3) + abs(y1 - y3)) == sqrt(abs(x2 - x4) + abs(y2 - y4)));
    }
    ~Square() {
        cout <<"Точка 1: " << x1 <<" " << y1 << "     Точка 2: " << x2 << " " << y2 << "     Точка 3: " << x3 <<" " << y3 << "     Точка 4: " << x4 <<" " << y4 << endl;
        cout << "~Square()" << endl;
    }
    void Area();
};

void Square::Area() {
    if (isSquare()) {
        cout << "Площадь: " << abs(x1 - x4) * abs(x1 - x4) << endl;
    }
    else {
        cout << "Фигура - не квадрат, создайте класс с правильными точками" << endl;
    }
}

class PaintedSquare :public Square {
protected:
    string color;
public:
    PaintedSquare() : Square() {
        color = "transparent";
        cout << "PaintedSquare()" << endl;
    }
    PaintedSquare(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, string color) : Square(x1,  y1,  x2,  y2,  x3,  y3,  x4,  y4) {
        cout << "PaintedSquare(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, string color)" << endl;
        this->color = color;
    }
    PaintedSquare(const PaintedSquare& sq) : Square(sq) {
        cout << "PaintedSquare(const PaintedSquare& sq)" << endl;
        color = sq.color;
    }
    ~PaintedSquare() {
        cout << "Цвет: "<< color << "     Точка 1: " << x1 << " " << y1 << "     Точка 2: " << x2 << " " << y2 << "     Точка 3: " << x3 << " " << y3 << "     Точка 4: " << x4 << " " << y4 << endl;
        cout << "~PaintedSquare()" << endl;
    }
    void Repainting(string color) {
        this->color = color;
    }
};

class NonPointerEqualSquares {
protected:
    Square sq1, sq2;
public:
    NonPointerEqualSquares() :sq1(), sq2() {
        cout << "NonPointerEqualSquares()" << endl;
    }
    NonPointerEqualSquares(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int x11, int y11, int x22, int y22, int x33, int y33, int x44, int y44):
        sq1(x1, y1, x2, y2, x3, y3, x4, y4), sq2(x11, y11, x22, y22, x33, y33, x44, y44)
    {
        cout << "NonPointerEqualSquares(x1, y1, x2, y2, x3, y3, x4, y4, x11, y11, x22, y22, x33, y33, x44, y44)" << endl;
    }
    NonPointerEqualSquares(const NonPointerEqualSquares& esq) : sq1(esq.sq1), sq2(esq.sq2) {
        cout << "NonPointerEqualSquares(const EqualSquares& sq)" << endl;
    }
    ~NonPointerEqualSquares() {
        cout << "~NonPointerEqualSquares()" << endl;
    }
};

class PointerEqualSquares {
protected:
    Square *sq1, *sq2;
public:
    PointerEqualSquares() {
        sq1 = new Square;
        sq2 = new Square;
        cout << "PointerEqualSquares()" << endl;
    }
    PointerEqualSquares(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int x11, int y11, int x22, int y22, int x33, int y33, int x44, int y44)
    {
        sq1 = new Square(x1, y1, x2, y2, x3, y3, x4, y4);
        sq2 = new Square(x11, y11, x22, y22, x33, y33, x44, y44);
        cout << "PointerEqualSquares(x1, y1, x2, y2, x3, y3, x4, y4, x11, y11, x22, y22, x33, y33, x44, y44)" << endl;
    }
    PointerEqualSquares(const PointerEqualSquares& pesq) {
        //sq1 = pesq.sq1;
        //sq2 = pesq.sq2;
        sq1 = new Square(*(pesq.sq1));
        sq2 = new Square(*(pesq.sq2));
        cout << "PointerEqualSquares(const PointerEqualSquares& sq)" << endl;
    }
    ~PointerEqualSquares()
    {
        cout << "~PointerEqualSquares()" << endl;
        delete sq1;
        delete sq2;
    }
};

int main() {
    setlocale(LC_ALL, "ru");

    //Square sq1;
    //Square sq2(2, 7, 5, 7, 5, 4, 2, 4);
    //Square sq3(sq2);

    //Square* sq1 = new Square();
    //Square* sq2 = new Square(2, 7, 5, 7, 5, 4, 2, 4);
    //Square* sq3 = new Square(*sq2);
    //delete sq1;
    //delete sq2;
    //delete sq3;

    //Square* sq1 = new PaintedSquare();
    //delete sq1;
    //PaintedSquare* sq2 = new PaintedSquare();

    //PaintedSquare psq(2, 7, 5, 7, 5, 4, 2, 4, "red");
    //psq.Repainting("green");

    //NonPointerEqualSquares esq1;
    //NonPointerEqualSquares esq2(2, 7, 5, 7, 5, 4, 2, 4, 2, 7, 5, 7, 5, 4, 2, 4);
    //NonPointerEqualSquares esq3(esq2);

    PointerEqualSquares* psq1 = new PointerEqualSquares();
    PointerEqualSquares* psq2 = new PointerEqualSquares(*psq1);
    delete psq1;
    delete psq2;
}