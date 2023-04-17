#include<iostream>
#include<math.h>
#include<ctime>
using namespace std;

struct Point {
    Point() : x(0), y(0) {};
    Point(float x, float y) : x(x), y(y) {};
    float x, y;
};

class Quadrilateral {
protected:
    Point p1, p2, p3, p4;
    float AB, BC, CD, DA, AC, BD;
public:
    Quadrilateral(){}
    Quadrilateral(const Point &p1, const Point& p2, const Point& p3, const Point& p4) {
        this->p1.x = p1.x; this->p1.y = p1.y;
        this->p2.x = p2.x; this->p2.y = p2.y;
        this->p3.x = p3.x; this->p3.y = p3.y;
        this->p4.x = p4.x; this->p4.y = p4.y;

        this->AB = CoordToLine(this->p1, this->p2);
        this->BC = CoordToLine(this->p2, this->p3);
        this->CD = CoordToLine(this->p3, this->p4);
        this->DA = CoordToLine(this->p4, this->p1);
        this->AC = CoordToLine(this->p1, this->p3);
        this->BD = CoordToLine(this->p2, this->p4);
    }

    virtual string classname() {
        return "Quadrilateral";
    }

    virtual bool isA(const string &who) {
        return who == "Quadrilateral";
    }

    float CoordToLine(const Point& p1, const Point& p2) {
        return sqrt(fabs(p1.x - p2.x) * fabs(p1.x - p2.x) + fabs(p1.y - p2.y) * fabs(p1.y - p2.y));
    }

    float GeronFunc(const float& a, const float& b, const float& c) {
        float p = (a + b + c) / 2;
        return sqrt(p * (p - a) * (p - b) * (p - c));
    }

    virtual void Area() {
        cout << "Area of a quadrilateral:" << GeronFunc(AB, BC, AC) + GeronFunc(CD, DA, AC) << '\n';
    }
    virtual ~Quadrilateral() {
        cout << "~Quadrilateral()" << endl;
    }
};

class Parallelogram : public Quadrilateral {
public:
    Parallelogram() {}
    Parallelogram(const Point& p1, const Point& p2, const Point& p3, const Point& p4) : Quadrilateral(p1, p2, p3, p4) {}

    string classname() override {
        return "Parallelogram";
    }

    bool isA(const string& who) {
        return (who == "Quadrilateral") || (who == "Parallelogram");
    }

    void Area() override{
        float S = 0.5 * (fabs(p2.y - p1.y)) * (fabs(p1.x - p4.x));
        cout << "Area of a parallelogram: " << S << '\n';
    }

    void propertyParallelogram() {
        cout << "Opposite sides of a parallelogram are equal. Opposite angles of a parallelogram are equal. The sum of the angles adjacent to one side is 180°" << endl;
    }
    ~Parallelogram() {
        cout << "~Parallelogram()" << endl;
    }
};

class Rectangle : public Quadrilateral {
public:
    Rectangle() {}
    Rectangle(const Point& p1, const Point& p2, const Point& p3, const Point& p4) : Quadrilateral(p1, p2, p3, p4) {}

    string classname() override {
        return "Rectangle";
    }

    bool isA(const string& who) {
        return (who == "Quadrilateral") || (who == "Rectangle");
    }

    void Area() override {
        float S = fabs(p2.y - p1.y) * (fabs(p1.x - p4.x));
        cout << "Area of a rectangle: " << S << '\n';
    }

    void propertyRectangle() {
        cout << "Opposite sides are pairwise parallel. The diagonals of any rectangle are equal." << endl;
    }
    ~Rectangle() {
        cout << "~Rectangle()" << endl;
    }
};

class Square : public Rectangle {
public:
    Square() {}
    Square(const Point& p1, const Point& p2, const Point& p3, const Point& p4) : Rectangle(p1, p2, p3, p4) {}

    string classname() override {
        return "Square";
    }

    bool isA(const string& who) {
        return (who == "Square") || (Rectangle::isA(who));
    }
    ~Square() {
        cout << "~Square()" << endl;
    }
};

int main() {
    srand(time(NULL));

    const int QUADRILATERAL_SIZE = 10;
    Quadrilateral* fig[QUADRILATERAL_SIZE];
    
    Point p1(1, 1), p2(1, 4), p3(6, 4), p4(6, 1);

    for (int i = 0; i < QUADRILATERAL_SIZE; ++i) {
        if (rand() % 3 == 0) {
            fig[i] = new Parallelogram(p1, p2, p3, p4);
        }
        else if (rand() % 3 == 1) {
            fig[i] = new Rectangle(p1, p2, p3, p4);
        }
        else {
            fig[i] = new Square(p1, p2, p3, p4);
        }
    }

    for (int i = 0; i < QUADRILATERAL_SIZE; ++i) {
        if (fig[i]->classname() == "Rectangle" || fig[i]->classname() == "Square") {
            ((Rectangle*)fig[i])->propertyRectangle();
            static_cast<Rectangle*>(fig[i])->propertyRectangle();
        }
        
        if (fig[i]->isA("Rectangle")) {
            static_cast<Rectangle*>(fig[i])->propertyRectangle();
        }

        Rectangle* rctngl = dynamic_cast<Rectangle*>(fig[i]);
        if (rctngl != nullptr) {
            rctngl->propertyRectangle();
        }
    }
}
