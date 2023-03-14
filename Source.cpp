#include<iostream>
#include<chrono>
#include<ctime>
#include<vector>
#include<list>

using namespace std;

template<typename T>
struct Node{
    T data;
    Node* pNext;
    Node (T data, Node* pNext = nullptr) {
        this->data = data;
        this->pNext = pNext;
    }
};

template<typename T>
class List {
public:
    List() {
        count = 0;
        root = nullptr;
    }

    void push_back(T data) {
        if (root == nullptr) {
            root = new Node<T>(data);
        }
        else {
            Node<T>* tmp = root;
            while (tmp->pNext != nullptr) {
                tmp = tmp->pNext;
            }
            tmp->pNext = new Node<T>(data);
        }
        ++count;
    }

    void push_front(T data) {
        if (root == nullptr) {
            root = new Node<T>(data);
        }
        else {
            Node<T>* tmp = new Node<T>(data);
            tmp->pNext = root;
            root = tmp;
        }
        ++count;
    }

    void pop_back() {
        removeAt(count - 1);
    }

    void pop_front() {
        Node<T>* tmp = root;
        root = root->pNext;
        delete tmp;
        --count;
    }

    void insertAt(T data, int index) {
        if (index == 0) {
            push_front(data);
        }
        else {
            Node<T>* tmp = root;
            for (int i = 0; i < index - 1; ++i) {
                tmp = tmp->pNext;
            }
            Node<T>* newNode = new Node<T>(data);
            newNode->pNext = tmp->pNext;
            tmp->pNext = newNode;
            ++count;
        }
    }

    void removeAt(int index) {
        if (index == 0) {
            pop_front();
        }
        else {
            Node<T>* tmp = root;
            for (int i = 0; i < index - 1; ++i) {
                tmp = tmp->pNext;
            }
            Node<T>* deleteNode = tmp->pNext;
            tmp->pNext = tmp->pNext->pNext;
            delete deleteNode;
            --count;
        }
    }

    void clear() {
        while (count) {
            pop_front();
        }
    }

    T& operator[](const int index) {
        if (index >= count) {
            throw invalid_argument("out of range");
        }
        int tmpCount = 0;
        Node<T>* tmp = root;
        while (tmp != nullptr) {
            if (tmpCount == index) {
                return tmp->data;
            }
            tmp = tmp->pNext;
            ++tmpCount;
        }
    }

    int GetCount() {
        return count;
    }

    ~List() {
        clear();
    }
private:
    Node<T> *root;
    int count;
};

class Person {
public:
    Person() {
        age = 0;
        name = "";
    }
    Person(int age, string name) {
        this->age = age;
        this->name = name;
    }
    string GetName() {
        return name;
    }
    int GetAge() {
        return age;
    }
private:
    int age;
    string name;
};

int main() {
    setlocale(LC_ALL, "ru");
    List<int>lst;
    List<Person*> prsn;
    lst.push_back(100);
    lst.push_back(1000);
    lst.push_back(10000);
    int n;
    cout << "¬ведите число повторений:\n" << "1. 100;\n" << "2. 1000;\n" << "3. 10000;\n";
    cin >> n;
    --n;
    auto start = chrono::high_resolution_clock::now();
    for (int i = 0; i < lst[n]; ++i) {
        switch (rand() % 5)
        {
            case 0:
                prsn.push_back(new Person(23, "Artur"));
            case 1:
                prsn.push_front(new Person(25, "Vlad"));
            case 2:
                prsn.insertAt(new Person(23, "Artur"), 0);
            case 3:
                delete prsn[0];
                prsn.pop_front();
            case 4:
                prsn[0];
        }
    }
    for (auto i = 0; i < prsn.GetCount(); ++i) {
        delete prsn[i];
    }
    auto end = chrono::high_resolution_clock::now();
    chrono::duration<float> duration = end - start;
    cout << "duration " << duration.count() << endl;
}