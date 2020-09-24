package com.algorithm;

import java.util.HashMap;
import java.util.Random;
import java.util.concurrent.TimeUnit;


/*
Multithreading
 */
public class Main {


    public static void main(String[] args) {

        Random random = new Random();
        int[] A_1000 = random.ints(10000, 0, 10000).toArray(); // fills array with 10000 random numbers from 0 to 10000
        int[] A_10000 = random.ints(100000, 0, 10000).toArray(); // fills array with 100000 random numbers from 0 to 10000
        int[] A_1000000 = random.ints(240000, 0, 10000).toArray(); // fills array with 1000000 random numbers from 0 to 10000
        int[] newArr = new int[(A_1000000.length-1)/4];
        int[] secondArr = new int[(A_1000000.length-1)/4];
        int[] thirdArr = new int[(A_1000000.length-1)/4];

        split(A_1000000,newArr,secondArr,thirdArr);

        Thread thread1 = new Thread(new Faster(newArr));
        Thread thread2 = new Thread(new Faster(secondArr));
        Thread thread3 = new Thread(new Faster(thirdArr));
        Thread thread4 = new Thread(new Faster(A_1000));
        Thread thread5 = new Thread(new Faster(A_10000));

        thread1.start();
        if(thread1.isAlive())
            System.out.println("object 1 is working");
        thread2.start();
        if(thread2.isAlive())
            System.out.println("object 2 is working");

        thread3.start();
        if(thread3.isAlive())
            System.out.println("object 3 is working");

        thread4.start();
        if(thread4.isAlive())
            System.out.println("object 4 is working");
        thread5.start();
        if(thread5.isAlive())
            System.out.println("object 5 is working");



    }


    //    Execution time for each n
    private static long execute(int[] A) {
        long startTime = System.nanoTime();
        ArrayTune(A);
        long elapsedTime = System.nanoTime() - startTime;
        System.out.println(TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS));
        return TimeUnit.MILLISECONDS.convert(elapsedTime, TimeUnit.NANOSECONDS);
    }

    private static void split(int[] A, int[] newArr, int[] secondArr,int[] second1Arr){
        newArr = new int[(A.length-1)/2];
        System.arraycopy(A,0,newArr,0,(A.length-1)/4);
        System.arraycopy(A,((A.length-1)/2),secondArr,0,(A.length-1)/4);
        System.arraycopy(A,((A.length-1)/4*3),second1Arr,0,(A.length-1)/4);

    }

    //  pseudocode into a computer code
    private static void ArrayTune(int[] A) {
        for (int i = 0; i < A.length - 1; i++) { // A.length == n-1 from the pseudocode
            for (int j = 0; j < A.length - 1; j++)
                if (A[i] >= A[j])
                    A[i] = A[i] + 1;
        }

    }


}

