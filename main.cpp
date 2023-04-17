#include<iostream>

using namespace std;

class Square {
protected:
    int x1, y1, x2, y2, x3, y3, x4, y4;
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
    Square(const Square* sq) {
        cout << "Square(const Square* sq)" << endl;
        x1 = sq->x1; y1 = sq->y1;
        x2 = sq->x2; y2 = sq->y2;
        x3 = sq->x3; y3 = sq->y3;
        x4 = sq->x4; y4 = sq->y4;
    }
    bool isSquare() {
        return (sqrt(abs(x1 - x2) + abs(y1 - y2)) == sqrt(abs(x1 - x4) + abs(y1 - y4)))
            && (sqrt(abs(x1 - x3) + abs(y1 - y3)) == sqrt(abs(x2 - x4) + abs(y2 - y4)));
    }
    ~Square() {
        cout << "~Square()" << endl;
    }
};

class PaintedSquare :public Square {
protected:
    string color;
public:
    PaintedSquare() : Square() {
        color = "transparent";
        cout << "PaintedSquare()" << endl;
    }
    PaintedSquare(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, string color) : Square(x1, y1, x2, y2, x3, y3, x4, y4) {
        cout << "PaintedSquare(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, string color)" << endl;
        this->color = color;
    }
    PaintedSquare(const PaintedSquare& sq) : Square(sq) {
        cout << "PaintedSquare(const PaintedSquare& sq)" << endl;
        color = sq.color;
    }
    PaintedSquare(const PaintedSquare *sq) : Square(*sq) {
        cout << "PaintedSquare(const PaintedSquare* sq)" << endl;
        color = sq->color;
    }
    void Repainting(string color) {
        this->color = color;
    }
    ~PaintedSquare() {
        cout << "~PaintedSquare()" << endl;
    }
};

void func1(Square sq) {
    //static_cast<PaintedSquare&>(sq).Repainting("privet");
}

void func2(Square* sq) {
    static_cast<PaintedSquare*>(sq)->Repainting("privet");
}

void func3(Square& sq) {
    static_cast<PaintedSquare&>(sq).Repainting("privet");
}

Square func1() {
    Square sq;
    return sq;
}

Square *func2() {
    Square sq;
    return &sq;
}

Square& func3() {
    Square sq;
    return sq;
}

Square func4() {
    Square* sq = new Square();
    return *sq;
}

Square* func5() {
    Square* sq = new Square();
    return sq;
}

Square& func6() {
    Square* sq = new Square();
    return *sq;
}

int main() {
    //Square sq1;
    //Square* sq2 = new PaintedSquare();

    //PaintedSquare psq1;
    //PaintedSquare* psq2 = new PaintedSquare();


    //func1(psq2);

    //delete psq2;

    //func2(sq2);
    //func3(*sq2);
    //func1(*sq2);//приведение типов невозможно, т.к. создается новый объект и указывает он на Square

    //func2(&psq1);
    //func3(psq1);
    //func1(psq1);//приведение типов невозможно, т.к. создается новый объект и указывает он на Square
    //delete sq2;
    //delete psq2;

    //Square sq1 = func1();


    //Square* sq2 = func2();
    //delete sq2;

    //Square sq3 = func3();

    //Square sq4 = func4();

    //Square* sq5 = func5();
    //delete sq5;

    //Square& sq6 = func6();
    //delete& sq6;
}
