<template>
  <div class="row">
      <div class="col-sm-4">
      </div>
      <b-card class="m-3 text-white text-center col-sm" bg-variant="dark">
        <h3>Welcome to the team!</h3>
        <div class="alert bg-warning" v-if="areMisMatchPasswords">
            Your passwords do not match, please try again.
        </div>
        <b-form @submit.prevent="changePassword">
            <div class="row my-3">
            <div class="col-sm">
                <label for="newPassword">
                    Please make a new password:
                </label>
                <b-form-input type="password" id="newPassword" v-model="newPassword" placeholder="New password" ></b-form-input>
            </div>
            <div class="col-sm">
                <label for="confirmPassword">
                    Confirm your password:
                </label>
                <b-form-input type="password" id="confirmPassword" v-model="confirmPassword" placeholder="Passwords must match" ></b-form-input>
            </div>
            </div>
            <b-button variant="outline-success" type="submit">Submit</b-button>
        </b-form>
      </b-card>
      
      <div class="col-sm-4">
      </div>
  </div>
</template>

<script>
import AuthService from '../services/AuthService';
export default {
    data() {
        return {
            newPassword : '',
            confirmPassword : '',
            areMisMatchPasswords: false,
        }
    },
    computed: {
        matchingPasswords() {
            return (this.newPassword === this.confirmPassword && this.newPassword != '');
        },

    },
    methods: {
        changePassword() {
            if (this.matchingPasswords) {
                AuthService.changePassword({ username: this.$store.state.user.username, password : this.newPassword}).then(response => {
                    if (response.status == 200) {
                        this.$router.push('volunteer-portal');
                    }
                })
            }
            else {
                this.areMisMatchPasswords = true;
            }
        }
    }
}
</script>

<style>

</style>