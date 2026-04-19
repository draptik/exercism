class NeedForSpeed {
    final int speed;
    final int batteryDrain;
    private int batteryStatus;
    private int distanceDriven;

    NeedForSpeed(int speed, int batteryDrain) {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.distanceDriven = 0;
        this.batteryStatus = 100;
    }

    public boolean batteryDrained() {
        return batteryStatus - batteryDrain < 0;
    }

    public int distanceDriven() {
        return distanceDriven;
    }

    public void drive() {
        if (batteryStatus - batteryDrain >= 0) {
            batteryStatus -= batteryDrain;
            distanceDriven += speed;
        }
    }

    public static NeedForSpeed nitro() {
        return new NeedForSpeed(50, 4);
    }
}

class RaceTrack {
    private final int distance;

    RaceTrack(int distance) {
        this.distance = distance;
    }

    public boolean canFinishRace(NeedForSpeed car) {
        while (car.distanceDriven() < distance && !car.batteryDrained()) {
            car.drive();
        }

        return car.distanceDriven() >= distance;
    }
}
