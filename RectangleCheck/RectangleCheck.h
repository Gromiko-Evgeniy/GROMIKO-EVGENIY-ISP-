#pragma once

#ifdef RECTANGLECHECK_EXPORTS
#define RECTANGLECHECK_API __declspec(dllexport)
#else
#define RECTANGLECHECK_API __declspec(dllimport)
#endif

extern "C" RECTANGLECHECK_API double __cdecl Perimeter(double a, double b);

extern "C" RECTANGLECHECK_API double __stdcall Area(double a, double b);

extern "C" RECTANGLECHECK_API double __cdecl Diagonal (double a, double b);

extern "C" RECTANGLECHECK_API bool __stdcall SquareCheck (double a, double b);

extern "C" RECTANGLECHECK_API double __stdcall DiagonalAngle (double a, double b);

extern "C" RECTANGLECHECK_API bool __stdcall Rectangle1IsBiggerByPerimeter(double a1, double b1, double a2, double b2);

extern "C" RECTANGLECHECK_API bool __stdcall Rectangle1IsBiggerByArea(double a1, double b1, double a2, double b2);

