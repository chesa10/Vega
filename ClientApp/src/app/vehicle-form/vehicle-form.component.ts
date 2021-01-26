import { Component, OnInit } from '@angular/core';
import { makeStateKey } from '@angular/platform-browser';
import { VehicleService } from '../services/vehicle.service';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: any = {
    features: [],
    contact: {}
  };
  features: any[];

  constructor(private vehicleService: VehicleService,
              private toastyService: ToastyService) { }

  ngOnInit() {
    var that = this;
    this.vehicleService.getMakes().subscribe(make => {
      that.makes = make;
    });

    this.vehicleService.getFeatures().subscribe(feature => that.features = feature);
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId)
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle).
      subscribe(v => console.log(v),
                err => {
                  this.toastyService.error({
                    title: "Error",
                    msg: "An unexpected error happend.",
                    theme: "boostrap",
                    showClose: true,
                    timeout: 5000
                  })
                });
  }

}
