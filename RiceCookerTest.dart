import 'package:test/test.dart';
import 'dart:io';

class RiceCookerTest {

  void main() {
  group('RiceCooker', () {
    late RiceCooker riceCooker;

    setUp(() {
      riceCooker = RiceCooker(10);
    });

    test('Adding items to the cooker', () {
      riceCooker.addItems([['Riz', 2, 'kg'], ['Eau', 1, 'L']]);
      expect(riceCooker._currentCapacity, equals(3.4));
    });

    test('Adding items exceeding maximum capacity', () {
      expect(
        () => riceCooker.addItems([['Riz', 9, 'L'], ['Eau', 2, 'L']]),
        throwsA(TypeMatcher<String>().having((e) => e, 'message', 'Capacité maximale dépassée')),
      );
    });

    test('Cooking with valid time', () {
      expect(() => riceCooker.cook(20), returnsNormally); 
    });

    test('Cooking when rice cooker needs repair', () {
      riceCooker.checkStatus(); 
      expect(() => riceCooker.cook(10), throwsA(TypeMatcher<String>().having((e) => e, 'message', 'Le rice cooker doit être réparé')));
    });

    test('Converting quantity to liters', () {
      expect(riceCooker._convertToLiters(2, 'kg'), equals(2.4));
      expect(riceCooker._convertToLiters(3, 'L'), equals(3));
    });

    test('Simulating cooking time', () {
      var stopwatch = Stopwatch()..start();
      riceCooker._simulateCooking(2);
      stopwatch.stop();
      expect(stopwatch.elapsed, greaterThanOrEqualTo(Duration(minutes: 2)));
    });
  });
}
}
