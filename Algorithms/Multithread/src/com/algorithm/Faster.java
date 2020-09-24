package com.algorithm;

import java.util.HashMap;
import java.util.concurrent.TimeUnit;

public class Faster implements Runnable {

    private int[] Array;
    HashMap<String, Long> results = new HashMap();


    public Faster(int[] array) {
        Array = array;
    }

    @Override
    public void run() {

        results.put("result", execute(Array));
        printResult(Array,results);

    }

    private long execute(int[] A) {
        long startTime = System.nanoTime();
        ArrayTune(A);
        long elapsedTime = System.nanoTime() - startTime;
        return TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS);
    }

    //  pseudocode into a computer code
    private void ArrayTune(int[] A) {
        for (int i = 0; i < A.length - 1; i++) { // A.length == n-1 from the pseudocode
            for (int j = 0; j < A.length - 1; j++)
                if (A[i] >= A[j])
                    A[i] = A[i] + 1;
        }

    }


    private void printResult(int[] Array, HashMap<String, Long> results) {
        String leftAlignFormat = "| %-15d | %-15s |%n";
        System.out.format("+-----------------+-----------------+%n");
        System.out.format("|Time, millis     |      n          |%n");
        System.out.format("+-----------------+-----------------+%n");
        System.out.format(leftAlignFormat, results.get("result"), "n = " +Array.length);
        System.out.format("+-----------------+-----------------+%n");
    }

}
