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
    PaintedSquare(const PaintedSquare* sq) : Square(*sq) {
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

unique_ptr<Square> print_info(unique_ptr<Square> up) {
    cout << up->isSquare() << endl;
    return move(up);
}

shared_ptr<Square> print_info(shared_ptr<Square> sp) {
    cout << sp->isSquare() << endl;
    return move(sp);
}

int main() {
    Square* p = new Square(0, 0, 0, 4, 6, 4, 6, 0);

    unique_ptr<Square> up1 = make_unique<Square >(1, 1, 1, 5, 7, 5, 7, 1);

    shared_ptr<Square> sp1 = make_shared<Square >(2, 2, 2, 6, 8, 6, 8, 2);

    cout << p->isSquare() << endl;
    cout << up1->isSquare() << endl;
    cout << sp1->isSquare() << endl;

    // unique_ptr<Square>up2 = up1; ERROR

    up1 = print_info(move(up1));
    //cout << up1->isSquare() << endl;


    sp1 = print_info(move(sp1));
    shared_ptr<Square>sp2 = sp1;
    cout << sp1->isSquare() << endl;
    cout << sp2->isSquare() << endl;
}
