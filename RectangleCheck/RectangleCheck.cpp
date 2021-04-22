#include "pch.h"
#include "RectangleCheck.h"
#include <math.h>
using namespace std;



double __cdecl Perimeter(double a, double b)
{
    double perimeter = (a + b) * 2;
    return perimeter;
} 

double __stdcall Area(double a, double b)
{
    return a * b;
}

double __cdecl Diagonal(double a, double b)
{
    double diagonal = sqrt(pow(a,2) + pow(b, 2));
    return diagonal;
}

bool __stdcall  SquareCheck(double a, double b)
{
    if (a == b)
    {
        return true;
    } 
    else
    {
        return false;
    }
}

double __stdcall DiagonalAngle (double a, double b)
{
    return atan(a/b);
}

bool __stdcall Rectangle1IsBiggerByPerimeter (double a1, double b1, double a2, double b2)
{
    return (Perimeter(a1, b1) > Perimeter(a2, b2));
}

bool  __stdcall Rectangle1IsBiggerByArea(double a1, double b1, double a2, double b2)
{
    return (Area(a1, b1) > Area(a2, b2));
}
