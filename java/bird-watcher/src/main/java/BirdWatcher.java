import java.util.Arrays;

class BirdWatcher {
    private final int[] birdsPerDay;

    public BirdWatcher(int[] birdsPerDay) {
        this.birdsPerDay = birdsPerDay.clone();
    }

    public int[] getLastWeek() {
        return birdsPerDay;
    }

    public int getToday() {
        return birdsPerDay[birdsPerDay.length - 1];
    }

    public void incrementTodaysCount() {
        birdsPerDay[birdsPerDay.length - 1]++;
    }

    public boolean hasDayWithoutBirds() {
        return Arrays.stream(birdsPerDay).anyMatch(x -> x == 0);
    }

    public int getCountForFirstDays(int numberOfDays) {
        int result = 0;
        int max = birdsPerDay.length < numberOfDays ? birdsPerDay.length : numberOfDays;
        for (int i = 0; i < max; i++) {
           result += birdsPerDay[i];
        }
        return result;
    }

    public int getBusyDays() {
        int result = 0;
        for (int i = 0; i < birdsPerDay.length; i++) {
            if (birdsPerDay[i] >= 5) {
                result++;
            }
        }
        return result;
    }
}
