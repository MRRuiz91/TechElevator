<template>
    <div>
         <b-button size="sm" class="mr-1">
            Approve
        </b-button>
        <b-button size="sm" class="mr-1">
            Deny
        </b-button>
   <b-table
        striped hover selectable :dark='true' b-table-select-single 
        :items="$store.state.pendingApplications" :fields="fields" sticky-header
        @row-selected="onRowSelected" responsive="sm" selected-variant="success"
    >
    <template #cell(Approve)>
        <b-button size="sm" class="mr-1">
            Approve
        </b-button>
    </template>
    <template #cell(Deny)>
        <b-button size="sm" class="mr-1">
            Deny
        </b-button>
    </template>
    </b-table>
    </div>
</template>

<script>
export default {
    data () {
        return {
            fields : [ 'Name', 'Response', 'Email', 'Phone Number', 'Approve', 'Deny'],
            SelectedApplication : {
                id: 0,
                username: '',
                status: 0,
            },
            
        }
    },
    methods: {
        /*updateStatus() {
            this.VolunteerService.ApproveOrDenyApplication(this.SelectedApplication).then(response => {}).catch(error => {});
        },*/
        onRowSelect(items) {
            this.SelectedApplication = items; 
        }
    },
}
</script>

<style>

</style>